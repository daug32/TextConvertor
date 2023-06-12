namespace TextConvertor.Core.Implementation;

internal class ProgressTimerNotifier : IDisposable
{
    private Timer? _timer;
    private const int DefaultInterval = 1000;

    private bool IsRunning => _timer != null;

    public int TotalStepsNumber { get; private set; }
    
    public int CurrentStepNumber { get; set; }
    
    public void Start(
        int totalStepsNumber,
        Action<string> notifyProgress )
    {
        if ( IsRunning )
        {
            throw new InvalidOperationException( "Can't run timer. Previous operation wasn't stopped yet" );
        }
     
        TotalStepsNumber = totalStepsNumber;   
        CurrentStepNumber = 0;
        double lastProgress = 0;

        _timer = new Timer( 
            _ =>
            {
                double progressThresholdToSendMessage = 1;

                double currentProgress = CalculateProgress();
                if ( currentProgress - lastProgress <= progressThresholdToSendMessage )
                {
                    return;
                }

                notifyProgress( $"Progress: {currentProgress}%" );
                lastProgress = currentProgress;
            },
            null,
            0,
            DefaultInterval );
    }

    public void StopIfRunning()
    {
        if ( !IsRunning )
        {
            return;
        }

        _timer!.Dispose();
        _timer = null;
    }

    public void Dispose()
    {
        StopIfRunning();
    }

    private double CalculateProgress()
    {
        return Math.Round( 100.0 * CurrentStepNumber / TotalStepsNumber, 4 );
    }
}
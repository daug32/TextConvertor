# TextConvertor
An automatization for Ficbook text sanitizing 

# What it can do

Hyphens: 
* Replaces "--" across all the text with dashes.<br>Example: "-- We are not the same, -- Aquasha said." -> "– We are not the same, – Aquasha said."
* Repalces hyphens at the start of each line with dashes.<br>Example: "- This place is wonderful!" -> "– This place is wonderful!"
* Solves these cases: "a -b" -> "a-b", "a- b" -> "a-b"

Spaces: 
* Trims spaces from the beginning and the end of each line.<br>Example: " One. Her mind filled up by voices. " -> "One. Her mind filled up by voices."
* Removes consicutive spaces.<br>Example: "He    was looking at   all those jackets  around here." -> "He was looking at all those jacket around here."

Tags:
* Adds \<tab\> tag where it needs to be.<br>Example: "– We are not the same, – Aquasha said." -> "<tab>– We are not the same, – Aquasha said."
* Adds \<center\> tag for "\*\*\*".<br>Example: "\*\*\*" -> "\<center\>\*\*\*\<\/center\>" 
  
Other: 
* Replaces "..." by a single three-points symbol.<br>Example: "And so on..." -> "And so on…"

// Name: Jonathan Winter
// Date Created: 02/03/21
// Most Recent Revision: 02/03/21
	
function validateInput() 
{
	// I thought about writing combinations of messages, but thought this would be the cleanest option.
	// You would send a combo by using if(n == "" && e == "") and stating that name and email need to be filled out.
	// Do this for all 7 combinations and you would be able to tell the user what they're still missing instead of one at a time.
	
	var n = document.forms["contactForm"]["name"].value;
	var e = document.forms["contactForm"]["email"].value;
	var p = document.forms["contactForm"]["phone"].value;
	
	if (n == "")
	{
		alert("Name must be filled out");
		return false;
	}
	
	if (e == "")
	{
		alert("Email must be filled out");
		return false;
	}
	
	if (p == "")
	{
		alert("Phone must be filled out");
		return false;
	}
	
	else
	{
		confirm("All required information has been provided.  Thank you for reaching out!");
		return true;
	}
}
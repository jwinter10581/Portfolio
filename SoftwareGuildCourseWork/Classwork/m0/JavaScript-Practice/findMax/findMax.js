var maxArray = [10, 200, 3000, 40, 9999, 500, 6000, 77, 888];
var maxDigit = 0;
var currentMax = 0;

for (var arrayPosition = 0; arrayPosition < maxArray.length; arrayPosition++)
	{
		if (maxArray[arrayPosition] > maxDigit)
		{
			maxDigit = maxArray[arrayPosition];
		}
	}

console.log("The max number of " + maxArray + " is: " + maxDigit);
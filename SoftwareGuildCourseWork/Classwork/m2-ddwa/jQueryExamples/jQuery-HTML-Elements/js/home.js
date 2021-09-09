$(document).ready(function () {
    
});

// Center all H1 elements.
$('H1').addClass('text-center');

// Center all H2 elements.
$('H2').addClass('text-center');

// Replace the class that is on the element containing the text "Team Up!" with the class page-header.
$('.well').addClass("page-header");
$('.well').removeClass("myBannerHeading");

// Change the text of "The Squad" to "Yellow Team".
$('#yellowHeading').html('Yellow Team');

// Change the background color for each team list to match the name of the team.
$('#orangeTeamList').css("background-color", "Orange");
$('#blueTeamList').css("background-color", "Blue");
$('#redTeamList').css("background-color", "Red");
$('#yellowTeamList').css("background-color", "Yellow"); // Relies on next prompt to display color

// Add Joseph Banks and Simon Jones to the Yellow Team list.
$('#yellowTeamList').append('<li>Joseph Banks</li>');
$('#yellowTeamList').append('<li>Simon Jones</li>');

// Hide the element containing the text "Hide Me!!!"
$('#oops').hide();

// Remove the element containing the text "Bogus Contact Info" from the footer.
$('#footerPlaceholder').remove();

// Add a paragraph element containing your name and email to the footer.The text must be in Courier font and be 24 pixels in height.
$('.footer').append('<p>Jonathan Winter</p>');
$('.footer').append('<p>jwinter10581@gmail.com</p>');
$('.footer').css({ 'font-family': "Courier", 'font-size': 24 });
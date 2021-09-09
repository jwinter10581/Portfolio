$(document).ready(function () {
    loadDVDs();
    addDVD();
    saveChanges();
    console.log("I am reading this file");
});

function loadDVDs() {
    clearDVDTable();
    var contentRows = $('#contentRows');

    $.ajax({
        type: 'GET',
        url: 'https://tsg-dvds.herokuapp.com/dvds',
        success: function (DVDArray) {
            $.each(DVDArray, function (index, DVD) {
                var title = DVD.title;
                var releaseYear = DVD.releaseYear;
                var director = DVD.director;
                var rating = DVD.rating;
                var id = DVD.id;

                var row = '<tr>';
                row += '<td>' + title + '</td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><button type="button" class="btn btn-info" onclick="showEditDVDForm(' + id + ')">Edit</button></td>';
                row += '<td><button type="button" class="btn btn-danger" onclick="deleteDVD(' + id + ')">Delete</button></td>';
                row += '</tr>';

                contentRows.append(row);
            })
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. List of DVDs not retrieved.'));
        }
    })
}

function clearDVDTable() {
    $('#contentRows').empty();
}

function addDVD() {
    $('#addCreateButton').click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#createDVD').find('input'));

        if (haveValidationErrors) {
            return false;
        }

        $.ajax({
            type: 'POST',
            url: 'https://tsg-dvds.herokuapp.com/dvd',
            data: JSON.stringify({
                title: $('#createDVDTitle').val(),
                releaseYear: $('#createReleaseYear').val(),
                director: $('#createDirector').val(),
                rating: $('#createRating').val(),
                notes: $('#createNotes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty();
                $('#createDVDTitle').val('');
                $('#createReleaseYear').val('');
                $('#createDirector').val('');
                $('#createRating').val('');
                $('#createNotes').val('');

                hideCreateDVDForm();
                loadDVDs();
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service.  Add DVD did not succeed.'));
            }
        })
    });
}

function showCreateDVDForm() {
    $('#errorMessages').empty();

    $('#movieTable').hide();
    $('#createAndSearchRow').hide();
    $('#createDVDHeader').show();
    $('#createDVD').show();
}

function hideCreateDVDForm() {
    $('#errorMessages').empty();
    $('#createDVDTitle').val('');
    $('#createReleaseYear').val('');
    $('#createDirector').val('');
    $('#createRating').val('');
    $('#createNotes').val('');

    $('#createDVDHeader').hide();
    $('#createDVD').hide();
    $('#createAndSearchRow').show();
    $('#movieTable').show();
}

function showEditDVDForm(id) {
    $('#errorMessages').empty();

    $.ajax({
        type: 'GET',
        url: 'https://tsg-dvds.herokuapp.com/dvd/' + id,
        success: function (DVD, status) {
            $('#editDVDTitle').val(DVD.title);
            $('#editReleaseYear').val(DVD.releaseYear);
            $('#editDirector').val(DVD.director);
            $('#editRating').val(DVD.rating);
            $('#editNotes').val(DVD.notes);
            $('#editDVDId').val(DVD.id);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling web service.  Edit DVD did not succeed.'));
        }
    })

    $('#movieTable').hide();
    $('#createAndSearchRow').hide();
    $('#editDVDHeader').show();
    $('#editDVD').show();
}

function hideEditDVDForm() {
    $('#errorMessages').empty();

    $('#editDVDTitle').val('');
    $('#editReleaseYear').val('');
    $('#editDirector').val('');
    $('#editRating').val('');
    $('#editNotes').val('');

    $('#editDVDHeader').hide();
    $('#editDVD').hide();
    $('#createAndSearchRow').show();
    $('#movieTable').show();
}

function saveChanges(id) {
    $('#editSaveButton').click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#editDVD').find('input'));

        if (haveValidationErrors)
        {
            return false;
        }

        $.ajax({
            type: 'PUT',
            url: 'https://tsg-dvds.herokuapp.com/dvd/' + $('#editDVDId').val(),
            data: JSON.stringify({
                id: $('#editDVDId').val(),
                title: $('#editDVDTitle').val(),
                releaseYear: $('#editReleaseYear').val(),
                director: $('#editDirector').val(),
                rating: $('#editRating').val(),
                notes: $('#editNotes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'datatype': 'json',
            'success': function () {
                $('#errorMessages').empty();
                hideEditDVDForm();
                loadDVDs();
            },
            'error': function () {
                $('#errorMessages')
                    .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service.  Update DVD did not succeed.'));
            }
        })
    })
}

function showSearchDVDForm(searchCat, searchTerm) {
    $('#errorMessages').empty();

    //var category = $('#searchCategory').val;
    //var term = $('#searchTerm').val;

    var link = searchCat + '/' + searchTerm;

    $('#searchButton').click(function (event) {
        $.ajax({
            type: 'GET',
            url: 'https://tsg.dvds.herokuapp.com/' + link,
            success: function (DVD) {
                $.each(DVD, function (DVD) {
                    var title = DVD.title;
                    var releaseYear = DVD.releaseYear;
                    var director = DVD.director;
                    var rating = DVD.rating;
                    var id = DVD.id;

                    $('#displayDVDHeader').append(DVD.title);
                    $('#displayDVDReleaseYear').append(DVD.releaseYear);
                    $('#displayDVDDirector').append(DVD.director);
                    $('#displayDVDRating').append(DVD.rating);
                    $('#displayDVDNotes').append(DVD.notes);

                    $('#createAndSearchRow').hide();
                    $('#movieTable').hide();
                    $('#displayDVDHeader').show();
                    $('#displayDVD').show();
                })
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Both Search Category and Search Term are required'));
            }
        })
    })
                        /*.text('Error calling web service. No DVD retrieved.'));*/
}

function hideSearchDVDForm() {
    $('#errorMessages').empty();

    $('#searchCategory').val('Search Category');
    $('#searchTerm').val('');

    $('#displayDVDHeader').hide();
    $('#displayDVD').hide();
    $('#createAndSearchRow').show();
    $('#movieTable').show();
}

function deleteDVD(id) {

    window.confirm("Are you sure you want to delete this DVD from your collection?");

    if (confirm('It has been deleted.')) {
        $.ajax({
            type: 'DELETE',
            url: 'https://tsg-dvds.herokuapp.com/dvd/' + id,
            success: function () {
                loadDVDs();
            }
        });
    }
    else {
        loadDVDs();
    }
}

function maxLengthCheck(input) {
    if (input.value.length > input.max.length) {
        input.value = input.value.slice(0, input.max.length);
    }
}

function isNumeric(event) {
    var theEvent = event || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid)
        {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text(message));
        });
        return true; //indicates that there were errors
    }
    else
    {
        return false; //indicates that there were no errors
    }
}
$(document).ready(function () {
    loadDVDs();
});

function loadDVDs() {
    clearDVDTable();
    var contentRows = $('#contentRows');

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/dvds',
        success: function (DVDArray) {
            $.each(DVDArray, function (index, DVD) {
                var title = DVD.title;
                var releaseYear = DVD.releaseYear;
                var director = DVD.director;
                var rating = DVD.rating;
                var id = DVD.id;

                var row = '<tr>';
                row += '<td><a onclick="displayDetails(' + id + ')">' + title + '</a></td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><button type="button" class="btn btn-warning" onclick="showEditForm(' + id + ')">Edit</button> <button type="button" class="btn btn-danger" onclick="deleteAlert(' + id + ')">Delete</button></td>';
                row += '</tr>';

                contentRows.append(row);
            });
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    });
}

function clearDVDTable() {
    $('#contentRows').empty();
}

function showCreateForm() {
    $('#errorMessages').empty();
    $('#initialState').hide();
    $('#createDVD').show();
}

function hideCreateForm() {
    $('#errorMessages').empty();
    $('#createDVD').hide();
    $('#createTitle').val('');
    $('#createReleaseYear').val('');
    $('#createDirector').val('');
    $('#createRating').val('');
    $('#createNotes').val('');
    $('#initialState').show();
}

function showEditForm(id) {
    $('#errorMessages').empty();

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/dvd/' + id,
        success: function (DVD, status) {
            $('#editHeader').text("Edit Title: " + DVD.title);
            $('#editTitle').val(DVD.title);
            $('#editReleaseYear').val(DVD.releaseYear);
            $('#editDirector').val(DVD.director);
            $('#editRating').val(DVD.rating);
            $('#editNotes').val(DVD.notes);
            $('#editId').val(DVD.id);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service.  Please try again later.'));
        }
    });

    $('#initialState').hide();
    $('#editDVD').show();
}

$('#editSaveButton').click(function (event) {
    $('#errorMessages').empty();
    var haveValidationErrors = checkEditInputErrors($('#editDVD').find('input'));

    if (/^[0-9]{4}$/.test($('#editReleaseYear').val()) == false) {
        $('#errorMessages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Please enter a 4-digit year.'));

        return false;
    }

    if (haveValidationErrors) {
        return false;
    }

    $.ajax({
        type: 'PUT',
        url: 'https://localhost:44301/dvd/' + $('#editId').val(),
        data: JSON.stringify({
            id: $('#editId').val(),
            title: $('#editTitle').val(),
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
            loadDVDs();
            hideEditForm();
        },
        'error': function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service.  Update DVD did not succeed.'));
        }
    })
})

function hideEditForm() {
    $('#errorMessages').empty();
    $('#editDVD').hide();
    $('#initialState').show();
}

$('#createAddButton').click(function (event) {
    $('#errorMessages').empty();

    var haveValidationErrors = checkCreateInputErrors($('#createDVD').find('input'));

    if (/^[0-9]{4}$/.test($('#createReleaseYear').val()) == false) {
        $('#errorMessages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Please enter a 4-digit year.'));

        return false;
    }

    //if (($('#createRating').val()) == 'None') {
    //    $('#errorMessages')
    //        .append($('<li>')
    //            .attr({ class: 'list-group-item list-group-item-danger' })
    //            .text('Please select a rating.'));

    //    return false;
    //}

    if (haveValidationErrors) {
        return false;
    }

    $.ajax({
        type: 'POST',
        url: 'https://localhost:44301/dvd',
        data: JSON.stringify({
            title: $('#createTitle').val(),
            director: $('#createDirector').val(),
            releaseYear: $('#createReleaseYear').val(),
            rating: $('#createRating').val(),
            notes: $('#createNotes').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function (data, status) {
            $('#errorMessages').empty();
            $('#createTitle').val('');
            $('#createDirector').val('');
            $('#createReleaseYear').val('');
            $('#createRating').val('');
            $('#createNotes').val('');
            loadDVDs();
            hideCreateForm();
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service.  Please try again later.'));
        }
    });
});

function displayDetails(id) {
    $('#errorMessages').empty();
    $('#initialState').hide();
    $('#displayDetails').show();

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/dvd/' + id,
        success: function (DVD) {
            $('#displayTitle').text(DVD.title);
            $('#displayReleaseYear').text(DVD.releaseYear);
            $('#displayDirector').text(DVD.director);
            $('#displayRating').text(DVD.rating);
            $('#displayNotes').text(DVD.notes);

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    });
}

function hideDetails() {
    $('#initialState').show();
    $('#displayDetails').hide();
}

function deleteAlert(id) {
    if (confirm('Are you sure you want to delete this DVD from your collection?')) {
        deleteDVD(id)
    }
}

function deleteDVD(id) {
    $.ajax({
        type: 'DELETE',
        url: "https://localhost:44301/dvd/" + id,
        success: function (status) {
            loadDVDs();
        }
    })
}

function searchDVDs() {
    $('#errorMessages').empty();

    var contentRows = $('#contentRows');

    if ($('#searchCategory').val() == '' || $('#searchTerm').val() == '') {

        $('#errorMessages')
            .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Both Search Category and Search Term are required.'));
        return;
    }
    else if ($('#searchCategory').val() === 'title') {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44301/dvds/title/' + $('#searchTerm').val(),
            success: function (DVDArray) {
                clearDVDTable();
                $.each(DVDArray, function (index, DVD) {
                    var title = DVD.title;
                    var releaseYear = DVD.releaseYear;
                    var director = DVD.director;
                    var rating = DVD.rating;
                    var id = DVD.id;

                    var row = '<tr>';
                    row += '<td><a onclick="displayDetails(' + id + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><button type="button" class="btn btn-warning" onclick="showEditForm(' + id + ')">Edit</button> <button type="button" class="btn btn-danger" onclick="deleteAlert(' + id + ')">Delete</button></td>';
                    row += '</tr>';

                    contentRows.append(row);
                })
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service. Please try again later.'));
            }
        })
    }
    else if ($('#searchCategory').val() === 'year') {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44301/dvds/year/' + $('#searchTerm').val(),
            success: function (DVDArray) {
                clearDVDTable();
                $.each(DVDArray, function (index, DVD) {
                    var title = DVD.title;
                    var releaseYear = DVD.releaseYear;
                    var director = DVD.director;
                    var rating = DVD.rating;
                    var id = DVD.id;

                    var row = '<tr>';
                    row += '<td><a onclick="displayDetails(' + id + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><button type="button" class="btn btn-warning" onclick="showEditForm(' + id + ')">Edit</button> <button type="button" class="btn btn-danger" onclick="deleteAlert(' + id + ')">Delete</button></td>';
                    row += '</tr>';

                    contentRows.append(row);
                })
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service. Please try again later.'));
            }
        })
    }
    else if ($('#searchCategory').val() === 'director') {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44301/dvds/director/' + $('#searchTerm').val(),
            success: function (DVDArray) {
                clearDVDTable();
                $.each(DVDArray, function (index, DVD) {
                    var title = DVD.title;
                    var releaseYear = DVD.releaseYear;
                    var director = DVD.director;
                    var rating = DVD.rating;
                    var id = DVD.id;

                    var row = '<tr>';
                    row += '<td><a onclick="displayDetails(' + id + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><button type="button" class="btn btn-warning" onclick="showEditForm(' + id + ')">Edit</button> <button type="button" class="btn btn-danger" onclick="deleteAlert(' + id + ')">Delete</button></td>';
                    row += '</tr>';

                    contentRows.append(row);
                })
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service. Please try again later.'));
            }
        })
    }
    else if ($('#searchCategory').val() === 'rating') {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44301/dvds/rating/' + $('#searchTerm').val(),
            success: function (DVDArray) {
                clearDVDTable();
                $.each(DVDArray, function (index, DVD) {
                    var title = DVD.title;
                    var releaseYear = DVD.releaseYear;
                    var director = DVD.director;
                    var rating = DVD.rating;
                    var id = DVD.id;

                    var row = '<tr>';
                    row += '<td><a onclick="displayDetails(' + id + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><button type="button" class="btn btn-warning" onclick="showEditForm(' + id + ')">Edit</button> <button type="button" class="btn btn-danger" onclick="deleteAlert(' + id + ')">Delete</button></td>';
                    row += '</tr>';

                    contentRows.append(row);
                })
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service. Please try again later.'));
            }
        })
    }
}

function checkInitialStateInputErrors(input) {
    $('#errorMessages').empty();
    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        return true; // true means there were errors
    } else {
        return false; // false means there were no errors
    }
}

function checkEditInputErrors(input) {
    $('#errorMessages').empty();
    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        return true; // true means there were errors
    } else {
        return false; // false means there were no errors
    }
}

function checkCreateInputErrors(input) {
    $('#errorMessages').empty();
    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        return true; // true means there were errors
    } else {
        return false; // false means there were no errors
    }
}

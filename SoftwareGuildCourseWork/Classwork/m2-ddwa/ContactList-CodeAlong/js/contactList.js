$(document).ready(function () {
    loadContacts();
    addContact();
    updateContact();
});

function loadContacts() {
    clearContactTable();
    var contentRows = $('#contentRows');

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44338/contacts',
        success: function (contactArray) {
            $.each(contactArray, function (index, contact) {
                var name = contact.firstName + ' ' + contact.lastName;
                var company = contact.company;
                var contactId = contact.contactId;

                var row = '<tr>';
                    row += '<td>' + name + '</td>';
                    row += '<td>' + company + '</td>';
                    row += '<td><button type="button" class="btn btn-info" onclick="showEditForm(' + contactId + ')">Edit</button></td>';
                    row += '<td><button type="button" class="btn btn-danger" onclick="deleteContact(' + contactId + ')">Delete</button></td>';
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

function addContact() {
    $('#addButton').click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#addForm').find('input'));

        if (haveValidationErrors)
        {
            return false;
        }

        $.ajax({
            type: 'POST',
            url: 'https://localhost:44338/contact',
            data: JSON.stringify({
                firstName: $('#addFirstName').val(),
                lastName: $('#addLastName').val(),
                company: $('#addCompany').val(),
                email: $('#addEmail').val(),
                phone: $('#addPhone').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty();
                $('#addFirstName').val('');
                $('#addLastName').val('');
                $('#addCompany').val('');
                $('#addEmail').val('');
                $('#addPhone').val('');
                loadContacts();
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service.  Please try again later.'));
            }
        })
    });
}

function clearContactTable() {
    $('#contentRows').empty();
}

function showEditForm() {
    $('#errorMessages').empty();

    $('#contactTable').hide();
    $('#editForm').show();
}

function hideEditForm() {
    $('#errorMessages').empty();

    $('#editFirstName').val('');
    $('#editLastName').val('');
    $('#editCompany').val('');
    $('#editEmail').val('');
    $('#editPhone').val('');

    $('#contactTable').show();
    $('#editForm').hide();
}

function showEditForm(contactId) {
    $('errorMessages').empty();

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44338/contact/' + contactId,
        success: function (data, status) {
            $('#editFirstName').val(data.firstName);
            $('#editLastName').val(data.lastName);
            $('#editCompany').val(data.company);
            $('#editEmail').val(data.email);
            $('#editPhone').val(data.phone);
            $('#editContactId').val(data.contactId);

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling web service.  Please try again later.'));
        }
    })

    $('#contactTable').hide();
    $('#editForm').show();
}

function updateContact(contactId) {
    $('#updateButton').click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#editForm').find('input'));

        if (haveValidationErrors)
        {
            return false;
        }

        $.ajax({
            type: 'PUT',
            url: 'https://localhost:44338/contact/' + $('#editContactId').val(),
            data: JSON.stringify({
                contactId: $('#editContactId').val(),
                firstName: $('#editFirstName').val(),
                lastName: $('#editLastName').val(),
                company: $('#editCompany').val(),
                email: $('#editEmail').val(),
                phone: $('#editPhone').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'datatype': 'json',
            'success': function () {
                $('#errorMessages').empty();
                hideEditForm();
                loadContacts();
            },
            'error': function () {
                $('#errorMessages')
                    .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service.  Please try again later.'));
            }
        })
    })
}

function deleteContact(contactId) {
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44338/contact/' + contactId,
        success: function () {
            loadContacts();
        }
    });
}

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function() {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0)
    {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger' })
                .text(message));
        });
        return true; //indicating that there were errors
    }
    else
    {
        return false; //indicating that there were no errors
    }
}
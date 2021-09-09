$(document).ready(function () {
    loadProducts();
});

// Used to format the price on the item display
var currencyFormatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD'
});

// Runs when the page opens, and is called when you use change return or make purchase.
function loadProducts() {
    var itemGrid = $('#itemGrid');
    var itemIdCounter = 1;

    $.ajax({
        type: 'GET',
        url: 'http://tsg-vending.herokuapp.com/items',
        success: function (itemArray) {
            $.each(itemArray, function (index, item) {
                var itemPositionId = itemIdCounter++;
                var itemId = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var button = '<input type="hidden" id="itemButton" />';
                button += '<button type="button"';
                button += 'id="selectButton' + itemId + '"';
                button += 'class="btn btn-primary"';
                button += 'onclick="selectItem(' + itemPositionId + ',' + itemId + ')">';
                button += '<p id="line1">' + itemPositionId + '</p>';
                button += '<p id="line2">' + name + '<br />' + currencyFormatter.format(price) + '<br /><br />Quantity Left: ' + quantity + '</p>';
                button += '</button>';

                itemGrid.append(button);
            })
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. List of items not retrieved.'));
        }
    })
}

function makePurchase() {
    $('#messageBox').empty();

    if ($('#itemInput').val() == "") {
        $('#messageBox').val("Please make a selection!");
    }
    else {
        $.ajax({
            type: 'POST',
            url: 'http://tsg-vending.herokuapp.com/money/' + $('#moneyInput').val() + '/item/' + $('#itemInputId').val(),
            success: function (changeDue) {
                var change = Number(changeDue.quarters);
                change += Number(changeDue.dimes);
                change += Number(changeDue.nickels);
                change += Number(changeDue.pennies);
                if (change === 0) {
                    $('#messageBox').val("Thank you!!!");
                }
                else {
                    $('#messageBox').val("Thank you!!!");
                    createChangeString(changeDue.quarters, changeDue.dimes, changeDue.nickels, changeDue.pennies);
                }
                resetDisplay();
            },
            error: function (errorResponse) {
                var errorObject = JSON.parse(errorResponse.responseText);
                var message = errorObject.message;
                $('#messageBox').val(message);
            }
        })
    }
}

function resetDisplay() {
    $('#moneyInput').val("0.00");
    $('#itemGrid').empty();
    loadProducts();
}

function selectItem(itemPositionId, itemId) {
    document.getElementById('itemInput').value = itemPositionId;
    document.getElementById('itemInputId').value = itemId;
    $('#changeOutput').val('');
    $('#messageBox').val('');
}

function addMoney(money) {
    document.getElementById('moneyInput').value = parseFloat((+document.getElementById("moneyInput").value) + money).toFixed(2);
    document.getElementById('changeOutput').value = '';
}

//This method runs and converts the Total $ In to variables for the createChangeString and then resets the display.
function returnChange() {

    var changeReturned = (document.getElementById('moneyInput').value) * 100; // Avoiding float math by using integers

    var quarters = 0;
    var dimes = 0;
    var nickels = 0;
    var pennies = 0;

    while (changeReturned >= 25) {
        changeReturned -= 25;
        quarters++;
    }
    while (changeReturned >= 10) {
        changeReturned -= 10;
        dimes++;
    }
    while (changeReturned >= 5) {
        changeReturned -= 5;
        nickels++;
    }
    while (changeReturned >= 1) {
        changeReturned -= 1;
        pennies++;
    }

    createChangeString(quarters, dimes, nickels, pennies);
    resetDisplay();
    $('#messageBox').val('');
    $('#itemInput').val('');
}

//This method is used for Make Purchase (if you have extra change) and Return Change to create the string display.
function createChangeString(quarters, dimes, nickels, pennies) {
    let changeString = '';

    if (quarters > 0) {
        if (quarters > 1) {
            changeString += quarters + ' quarters';
        }
        else {
            changeString += quarters + ' quarter';
        }
    }

    if (dimes > 0) {
        if (quarters > 0) {
            changeString += ', '
        }
        if (dimes > 1) {
            changeString += dimes + ' dimes';
        }
        else {
            changeString += dimes + ' dime';
        }
    }

    if (nickels > 0) {
        if (quarters > 0 || dimes > 0) {
            changeString += ', '
        }
        if (nickels > 1) {
            changeString += nickels + ' nickels';
        }
        else {
            changeString += nickels + ' nickel';
        }
    }

    if (pennies > 0) {
        if (nickels > 0 || quarters > 0 || dimes > 0) {
            changeString += ', '
        }
        if (pennies > 1) {
            changeString += pennies + ' pennies';
        }
        else {
            changeString += pennies + ' penny';
        }
    }

    document.getElementById('changeOutput').value = changeString;
}
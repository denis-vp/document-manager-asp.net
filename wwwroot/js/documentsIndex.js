let previousPreviousSearch = "";
let previousSearch = "";

const cyclePreviousSearch = (newSearch) => {
    previousPreviousSearch = previousSearch;
    previousSearch = newSearch;
    if (previousPreviousSearch === "") {
        $('#previousSearch').text(previousPreviousSearch);
    } else {
        $('#previousSearch').text('Previous search: ' + previousPreviousSearch);
    }
}

const getAllDocuments = () => {
    cyclePreviousSearch("");

    $.ajax({
        url: '/Documents/Index',
        type: 'GET',
        success: (response) => {
            $('#documentsTable').html(response);
        },
        error: (error) => {
            console.log(error.responseText);
        }
    });
};

window.onload = () => {
    $('#searchType').keypress((event) => {
        if (event.which !== 13) {
            return;
        }

        event.preventDefault();

        $('#searchFormat').val("");

        const searchString = $('#searchType').val();
        cyclePreviousSearch(searchString);

        if (searchString.length === 0) {
            getAllDocuments();
            return;
        }

        $.ajax({
            url: '/Documents/Index?searchType=' + searchString,
            type: 'GET',
            success: (response) => {
                $('#documentsTable').html(response);
            },
            error: (error) => {
                console.log(error.responseText);
            }
        });
    });

    $('#searchFormat').keypress((event) => {
        if (event.which !== 13) {
            return;
        }

        event.preventDefault();

        $('#searchType').val("");

        const searchString = $('#searchFormat').val();
        cyclePreviousSearch(searchString);

        if (searchString.length === 0) {
            getAllDocuments();
            return;
        }

        $.ajax({
            url: '/Documents/Index?searchFormat=' + searchString,
            type: 'GET',
            success: (response) => {
                $('#documentsTable').html(response);
            },
            error: (error) => {
                console.log(error.responseText);
            }
        });
    });
}
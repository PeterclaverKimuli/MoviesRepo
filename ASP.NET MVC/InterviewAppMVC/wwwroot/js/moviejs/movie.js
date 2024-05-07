var url = "http://localhost:5062/api/movies";

function deleteMovie(button, id) {
    var $button = $(button);

    if (confirm("Are you sure you want to delete this movie?")) {
        $.ajax({
            url: url + "/" + id,
            method: "DELETE",
            success: function () {
                $button.parents("tr").remove();
            }
        })
    }
}
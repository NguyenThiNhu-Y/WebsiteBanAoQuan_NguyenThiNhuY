function uploadImage(file) {
    var formData = new FormData();
    formData.append("file", file);
    $.ajax({
        data: formData,
        type: "POST",
        url: '/Post/SaveFile',
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnImageURL) {
            //Asign return Image URL to HTML.Hiddenfor
            $('#ImagePath').val(returnImageURL);
            //Call this method to view Image
            ViewImage(returnImageURL);
        }
    });
}
function ViewImage(url) {
    if (url) {
        $('#ImageViewing').attr('src', url);
    }
}
$('#pickupImage').change(function () {
    //call upload method
    uploadImage(this.files[0]);
});
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#UploadBtn').click(function () {
    var fileUpload = $("#Files").get(0);
    var files = fileUpload.files;
    // Create FormData object      
    var fileData = new FormData();
    // Looping over all files and add it to FormData object      
    for (var i = 0; i < files.length; i++) {
        fileData.append(files[i].name, files[i]);
    }
    $.ajax({
        url: '/Home/UploadFiles',
        type: "POST",
        contentType: false, // Not to set any content header      
        processData: false, // Not to process data      
        data: fileData,
        async: false,
        success: function (result) {
            if (result != "") {
                $('#FileBrowse').find("*").prop("disabled", true);
                LoadProgressBar(result); //calling LoadProgressBar function to load the progress bar.    
            }
        },
        error: function (err) {
            alert(err.statusText);
        }
    });
}); 
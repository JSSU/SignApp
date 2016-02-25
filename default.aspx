﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SignApp.d" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Signature App</title>

</head>
<body>

    <script src="jQuery/jquery-2.0.3.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <script src="scripts/signature_pad.js"></script>

    <script>
        $(document).ready(function () {
            // Handler for .ready() called.

            var wrapper = document.getElementById("signature-pad"),
            clearButton = wrapper.querySelector("[data-action=clear]"),
            saveButton = wrapper.querySelector("[data-action=save]"),
            canvas = wrapper.querySelector("canvas"),
            signaturePad;

            // Adjust canvas coordinate space taking into account pixel ratio,
            // to make it look crisp on mobile devices.
            // This also causes canvas to be cleared.
            function resizeCanvas() {
                var ratio = window.devicePixelRatio || 1;
                canvas.width = canvas.offsetWidth * ratio;
                canvas.height = canvas.offsetHeight * ratio;
                canvas.getContext("2d").scale(ratio, ratio);
            }

            window.onresize = resizeCanvas;
            resizeCanvas();

            signaturePad = new SignaturePad(canvas);

            clearButton.addEventListener("click", function (event) {
                signaturePad.clear();
            });

            saveButton.addEventListener("click", function (event) {
                if (signaturePad.isEmpty()) {
                    alert("Please provide signature first.");
                } else {
                    SaveImage(signaturePad.toDataURL());
                }
            });
        });

        var uri = 'api/signatures';

        function SaveImage(dataURL) {
            dataURL = dataURL.replace('data:image/png;base64,', '');
            var data = JSON.stringify(
                               {
                                   value: dataURL
                               });

            $.ajax({
                type: "POST",
                url: "/api/signature",
                contentType: false,
                processData: false,
                data: data,
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    alert("Done!");
                },
                error: onWebServiceFailed
            });
        }

        function onWebServiceFailed(result, status, error) {
            var errormsg = eval("(" + result.responseText + ")");
            alert(errormsg.Message);
        }
    </script>

        <div class="page-header">
            <h1>
                <center>MOTOR VEHICLE ACCIDENT REPORT DIAGRAM</center>
            </h1>
        </div>
        <div class="container detail" style="float:left; width:20%;">
            <span id="lbID" for="inpID" style="margin-right:20px;">ID</span>
            <input type="text" id="inpID" class="form-control" style="display:inline;" />
        </div>
        <div class="container" style="float:right; width:80%;">


            <div class="panel panel-default">
                <div class="panel-body" id="signature-pad">
                    <div>
                        <canvas style="width: 100%; height: 600px;"></canvas>
                    </div>
                    <div>
                        <div class="alert alert-info">Draw above</div>
                        <button data-action="clear" class="btn btn-info">Clear</button>
                        <button data-action="save" class="btn btn-success">Save</button>
                    </div>
                </div>
            </div>
        </div>

</body>
</html>
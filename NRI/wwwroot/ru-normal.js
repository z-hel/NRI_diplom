(function (jsPDFAPI) {
var font = '4A0K4Q0K4g0K4w0K5A0K5Q0K5g0K5w0K6A0K6g0K6w0K7A0K7Q0K7g0K7w0K8A0K8Q0K8g0K8w0K9A0K9Q0K9g0K9w0K+A0K+g0K+w0K/A0K/Q0K/g0K/w==';
var callAddFont = function () {
this.addFileToVFS('ru-normal.ttf', font);
this.addFont('ru-normal.ttf', 'ru', 'normal');
};
jsPDFAPI.events.push(['addFonts', callAddFont])
 })(jsPDF.API);
//function openPopup() {
//    var control = window.event.srcElement;
//}

var oWnd = null;
var lblHeight = null;
var lblWidth = null;
var control = null;
var sfuncion = null;
var x = 0;
var y = 0;
var urlBox = null;
var breloadclose = null;
var ismaximize = null;


function pageLoad() {
    //urlBox = $get("urlBox");
}

function onShow() {
    eval("oWnd.show()");
}

function OnClientActivate(sender) {
    //get a reference to the RadWindow object
    oWnd = sender;
    oWnd.setUrl(urlBox);
    configureUI(oWnd);
}

function SetWindow(sender) {
    oWnd = sender;
    oWnd.setSize(lblWidth, lblHeight);
    if (ismaximize == true) oWnd.maximize();
    else oWnd.moveTo(x, y);
}

function SetWindowBehavior(sender) {
    oWnd = sender;
    oWnd.setUrl(urlBox);
//    oWnd.set_height(lblHeight);
//    oWnd.set_width(lblWidth);
    if (ismaximize == true) oWnd.maximize();
    else oWnd.moveTo(x, y);
    //oWnd.setActive(true);
    //configureUI(oWnd);
}

function OnClientclose(sender) {
    if (breloadclose == true) {
        eval(sfuncion);
        //window.location.href = window.location.href;
    }
}

function configureUI(oWnd) {
    //get RadWindow's bounds
    //var bounds = oWnd.getWindowBounds();
}


function OnClientPageLoad(oWnd) {

    //dynamically change the title of RadWindow so it matches the current URL
    //this must be done in OnClientPageLoad, otherwise the window will get the title
    //that is set in the title section of content page's head. 
    var originalUrl = oWnd.get_navigateUrl();
    var websiteName = getWebsiteName(originalUrl);
    oWnd.set_title(websiteName);

    //Change RadWindow icon to the favicon.ico icon of the opened site
    var icon = $telerik.getElementByClassName(oWnd.get_popupElement(), "windowicon", "A");
    if (icon) {
        icon.style.background = "url(" + originalUrl + "/favicon.ico) no-repeat 0 0";
    }
}

function getWebsiteName(websiteName) {
    url = websiteName.replace("http://www", "");
    url = url.substr(0, url.indexOf("."));
    url = url.charAt(0).toUpperCase() + url.substr(1);
    return url;
}

function changeUrl() {
    oWnd.setUrl(urlBox);
    configureUI(oWnd);
}

//function openPopup(url, ctrl, reloadclose, sfun, ancho, alto, _x, _y, ismax) {
//    //urlBox = url;
//    if (ctrl != '')
//        control = document.getElementById(ctrl);
//    breloadclose = reloadclose;
//    if (breloadclose)
//        sfuncion = sfun;
//    //lblHeight = alto;
//    //lblWidth = ancho;
//    //x = _x;
//    //y = _y;
//    //ismaximize = ismax;
//    var oWindow = window.radopen(url, "rwPopup");
//    oWindow.setSize(ancho, alto);
//    if (ismax == true) oWindow.maximize();
//    else oWindow.moveTo(_x, _y);
//    //$find('<%= rwPopup.ClientID%>').show();
//}




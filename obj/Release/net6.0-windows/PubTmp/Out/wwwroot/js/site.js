// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




	document.addEventListener("contextmenu", function (e) {
		e.preventDefault();
	}, false);
	document.addEventListener("keydown", function (e) {
	
		// "I" 
		if (e.ctrlKey && e.shiftKey && e.keyCode == 73) {
			disabledEvent(e);
		}
		// "J" 
		if (e.ctrlKey && e.shiftKey && e.keyCode == 74) {
			disabledEvent(e);
		}
		// "S" 
		if (e.keyCode == 83 && (navigator.platform.match("Mac") ? e.metaKey : e.ctrlKey)) {
			disabledEvent(e);
		}
		// "U" 
		if (e.ctrlKey && e.keyCode == 85) {
			disabledEvent(e);
		}
		// "F12" 
		if (event.keyCode == 123) {
			disabledEvent(e);
		}
	}, false);
	function disabledEvent(e) {
		if (e.stopPropagation) {
			e.stopPropagation();
		} else if (window.event) {
			window.event.cancelBubble = true;
		}
		e.preventDefault();
		return false;
}


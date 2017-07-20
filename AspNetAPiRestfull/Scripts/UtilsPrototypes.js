"use strict";

function Teste(params) {
    var valor = "111.111.11,11";
    console.log(valor.replace('.',''));
}
function rangeFinal(control){
    control.setSelectionRange(control.length,control.length); 
};
function formatCurrency(x) {
    if(!isNaN(x.value)){
        var vlrSemFormatacao = x.value.toString();
        var xLengh = parseInt(vlrSemFormatacao.length);  
        if(xLengh >= 3){
             x.value = vlrSemFormatacao.ConvertToFloat().FormatMoney(2,".", ",");                   
        }
    }else{
        x.value = 0;         
    }
}

String.prototype.ConvertToFloat = function() {
    if(!isNaN(this)){
        var xLengh = parseInt(this.length);
        var vlrFinal = xLengh > 2 ? parseFloat(this.substring(0,(xLengh-2)) +"."+ this.substring((xLengh-2),xLengh)): parseInt(this);
        return vlrFinal;
    }
    return 0;
};
Number.prototype.FormatMoney = function(places, thousand, decimal, symbol) {
	places = !isNaN(places = Math.abs(places)) ? places : 2;
	symbol = symbol !== undefined ? symbol : "";
	thousand = thousand || ",";
	decimal = decimal || ".";
	var number = this, 
	    negative = number < 0 ? "-" : "",
	    i = parseInt(number = Math.abs(+number || 0).toFixed(places), 10) + "",
	    j = (j = i.length) > 3 ? j % 3 : 0;
	return symbol + negative + (j ? i.substr(0, j) + thousand : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousand) + (places ? decimal + Math.abs(number - i).toFixed(places).slice(2) : "");
};
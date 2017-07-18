"use strict";
function formatCurrency(x) {
    if(!isNaN(x.value)){
        var xLengh = parseInt(x.value.length);
        var xFloat = xLengh > 2 ? parseFloat(x.value.substring(0,(xLengh-2)) +"."+ x.value.substring((xLengh-2),xLengh)): parseInt(x.value);
        console.log(xFloat);                      
        if(xLengh == 3){
            x.value = x.value.substring(0,1)+","+ x.value.substring(1,3);            
        }else if (xLengh > 3){
            
        }
    }
}

String.prototype.replaceAll = function (charAntes,charSubs) {
    var qtd = (this.match(/charAntes/g) || []).length;

    var vlr, i;
    while (i > length){
        vlr = vlr.replace(charAntes,charSubs);
        i++;
    }
    return vlr;
}
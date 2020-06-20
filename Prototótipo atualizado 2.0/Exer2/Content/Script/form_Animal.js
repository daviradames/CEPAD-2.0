
    function mascaraData(campoData){
    var data = campoData.value;
    if (data.length == 2){
        data = data + '/';
    document.forms[0].data.value = data;
    return true;
    }
    }

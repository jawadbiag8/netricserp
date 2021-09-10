
$(function () {
    $('#svcno').on('keydown', function (e) { -1 !== $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) || /65|67|86|88/.test(e.keyCode) && (!0 === e.ctrlKey || !0 === e.metaKey) || 35 <= e.keyCode && 40 >= e.keyCode || (e.shiftKey || 48 > e.keyCode || 57 < e.keyCode) && (96 > e.keyCode || 105 < e.keyCode) && e.preventDefault() });
    $('#cnic').on('keydown', function (e) { -1 !== $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) || /65|67|86|88/.test(e.keyCode) && (!0 === e.ctrlKey || !0 === e.metaKey) || 35 <= e.keyCode && 40 >= e.keyCode || (e.shiftKey || 48 > e.keyCode || 57 < e.keyCode) && (96 > e.keyCode || 105 < e.keyCode) && e.preventDefault() });
    $('#NoOfChildren').on('keydown', function (e) { -1 !== $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) || /65|67|86|88/.test(e.keyCode) && (!0 === e.ctrlKey || !0 === e.metaKey) || 35 <= e.keyCode && 40 >= e.keyCode || (e.shiftKey || 48 > e.keyCode || 57 < e.keyCode) && (96 > e.keyCode || 105 < e.keyCode) && e.preventDefault() });
    $("#FullName").keypress(function (event) {
        var inputValue = event.which;
        debugger;
        // allow letters and whitespaces only.
        if (!(inputValue >= 65 && inputValue <= 120) && (inputValue != 32 && inputValue != 0) && (inputValue != 8) && (inputValue != 45)) {
            event.preventDefault();
        }
    });
})

function  SaveTag () {
    $('#NewTagAdd input[type="text"], #NewTagAdd textarea').each(function resetData() {
        $(this).val($(this).val().replace(/<(?=[a-z<!\/?])/gi, "< "));
    });
    var orgObj = { TagText: $("#TagText").val(), TagDescription: $("#TagDescription").val() };
    var TagText = $("#TagText").val();
    var TagDescription = $("#TagDescription").val();
    if (TagText == '') {
        $("#spanErrorTag").removeClass('hide');
    }
    else {
        $.ajax({
            type: 'POST',
            url: '/Attachment/AddTag',
            dataType: "JSON",
            data: orgObj,
            success: function (data) {
                if (data > 0) {
                    document.getElementById('TagText').value = "";
                    document.getElementById('TagDescription').value = "";
                    $('#NewTagAdd').dialog("close");
                    alert("Tag has been added successfully")
                }
                if (data = 0) {
                    $("#spanErrorTag").removeClass('hide');
                }
                if (data = -1) {
                    $("#spanErrorTagExist").removeClass('hide');
                }

            }

        });
    }
}

$(document).on('click', '.tag1 a', function (event) {
    $(this).parent().remove();
    var aa = 0;
    $("#tags1 span.tag1").each(function (index, elem) {
        aa += $(this).find("input").val() + ',';
    });
    $("#TagsID").val(aa);
});

$(document).on('click', '.tag2 a', function (event) {
   
    $(this).parent().remove();

    var aa = 0;
    $("#tags2 span.tag2").each(function (index, elem) {
        aa += $(this).find("input").val() + ',';
    });
    $("#NBMTagsID").val(aa);
});

$(document).on('click', '.tag3 a', function (event) {
    $(this).parent().remove();

    var aa = 0;
    $("#tags3 span.tag3").each(function (index, elem) {
        aa += $(this).find("input").val() + ',';
    });
    $("#STTagName").val(aa);
});


$(document).on('keyup paste', '#tagtextId1', function (event) {
    var strTagText = $("#tagtextId1").val();
    if ($("#tagtextId1").val().length > 1) {
        $.ajax({
            type: 'POST',
            url: '/Attachment/GetTags',
            dataType: "json",
            data: { str: strTagText },
            success: function (data) {
                var tags = data
                if (tags != []) {
                   $('#tags1').tagSelector1(tags, 'tags1');
                   
                }
               
            }
        });
    }
});

$.fn.tagSelector1 = function (source, name) {
    return this.each(function () {
        var selector = $(this),
            input = $('input[id="tagtextId1"]', this);
        input.keydown(function (e) {
            if (e.keyCode === $.ui.keyCode.TAB && $(this).data('autocomplete').menu.active)
                e.preventDefault();
        })
            .autocomplete({
                minLength: 1,
                //source:source,
                source: function (request, response) {
                    response($.map(source.tags, function (item) {
                        return {
                            value: item.Value,
                            id: item.Key
                        }
                    }));
                },
                focus: function () {
                    // prevent value inserted on focus
                    return false;
                },
                select: function (event, ui) 
                {
                    var flagAlreadyExist = false;
                    $("#tags1 span.tag1").each(function (index, elem) {
                        if ($(this).find("input").val() == ui.item.id)
                            flagAlreadyExist = true;
                    });
                    if (flagAlreadyExist == false) {
                        $("#tagtextId1").val("");
                        var tag = $('<span class="tag1"/>')
                        .text(ui.item.value + ' ')
                        .append('<a>×</a>')
                        .append($('<input type="hidden"/>').attr('name', name).val(ui.item.id))
                        .insertBefore($("#tagtextId1"));
                        var aa = 0;
                        $("#tags1 span.tag1").each(function (index, elem) {
                            aa += $(this).find("input").val() + ',';
                        });
                        $("#TagsID").val(aa);
                        var bb = " ";
                        $("#tags1 span.tag1").each(function (e) {
                            bb += $(this).text() + ',';
                        });
                        $("#TagName").val(bb);
                        ui.item.value = "";
                        return true;
                    }

                }
                
            });
    });
};

$(document).on('keyup paste', '#tagtextId2', function (event) {
    var strTagText = $("#tagtextId2").val();
    if ($("#tagtextId2").val().length > 1) {
        $.ajax({
            type: 'POST',
            url: '/Attachment/GetTags',
            dataType: "json",
            data: { str: strTagText },
            success: function (data) {
                var tags = data
                if (tags != []) {
                    $('#tags2').tagSelector2(tags, 'tags2');
                }
            }
        });
    }
});

$.fn.tagSelector2 = function (source, name) {
    return this.each(function () {
        var selector = $(this),
            input = $('input[id="tagtextId2"]', this);
        input.keydown(function (e) {
            if (e.keyCode === $.ui.keyCode.TAB && $(this).data('autocomplete').menu.active)
                e.preventDefault();
        })
            .autocomplete({
                minLength: 1,
                //source:source,
                source: function (request, response) {
                    response($.map(source.tags, function (item) {
                        return {
                            value: item.Value,
                            id: item.Key
                        }
                    }));
                },
                focus: function () {
                    // prevent value inserted on focus
                    return false;
                },

                select: function (event, ui) {
                    var flagAlreadyExist = false;
                    $("#tags2 span.tag2").each(function (index, elem) {
                        if ($(this).find("input").val() == ui.item.id)
                            flagAlreadyExist = true;
                    });
                    if (flagAlreadyExist == false) {
                        var tag = $('<span class="tag2"/>')
                        .text(ui.item.value + ' ')
                        .append('<a>×</a>')
                        .append($('<input type="hidden"/>').attr('name', name).val(ui.item.id))
                        .insertBefore($("#tagtextId2"));
                        var aa = 0;
                        $("#tags2 span.tag2").each(function (index, elem) {
                            aa += $(this).find("input").val() + ',';
                        });
                        $("#NBMTagsID").val(aa);
                        var bb = " ";
                        $("#tags2 span.tag2").each(function (e) {
                            bb += $(this).text() + ',';
                        });
                        $("#NBMTagName").val(bb);
                        ui.item.value = "";
                        return true;
                    }
                }
            });

    });
};

$(document).on('keyup paste', '#tagtextId3', function (event) {
    var strTagText = $("#tagtextId3").val();
    if ($("#tagtextId3").val().length > 1) {
        $.ajax({
            type: 'POST',
            url: '/Attachment/GetTags',
            dataType: "json",
            data: { str: strTagText },
            success: function (data) {
                var tags = data
                if (tags != []) {
                    $('#tags3').tagSelector3(tags, 'tags3');
                }
            }
        });
    }
});

$.fn.tagSelector3 = function (source, name) {
    return this.each(function () {
        var selector = $(this),
            input = $('input[id="tagtextId3"]', this);
        input.keydown(function (e) {
            if (e.keyCode === $.ui.keyCode.TAB && $(this).data('autocomplete').menu.active)
                e.preventDefault();
        })
            .autocomplete({
                minLength: 1,
                source: function (request, response) {
                    response($.map(source.tags, function (item) {
                        return {
                            value: item.Value,
                            id: item.Key
                        }
                    }));
                },
                focus: function () {
                    // prevent value inserted on focus
                    return false;
                },
                select: function (event, ui) {
                    var flagAlreadyExist = false;
                    $("#tags3 span.tag3").each(function (index, elem) {
                        if ($(this).find("input").val() == ui.item.id)
                            flagAlreadyExist = true;
                    });
                    if (flagAlreadyExist == false) {
                        var tag = $('<span class="tag3"/>')
                        .text(ui.item.value + ' ')
                        .append('<a>×</a>')
                        .append($('<input type="hidden"/>').attr('name', name).val(ui.item.id))
                        .insertBefore($("#tagtextId3"));
                        var aa = 0;
                        $("#tags3 span.tag3").each(function (index, elem) {
                            aa += $(this).find("input").val() + ',';
                        });
                        $("#STTagsID").val(aa);
                        var bb = " ";
                        $("#tags3 span.tag3").each(function (e) {
                            bb += $(this).text() + ',';
                        });
                        $("#STTagName").val(bb);
                        ui.item.value = "";
                        return true;
                    }
                }
            });
    });
};

$(document).on('keyup paste', '#tagtext', function (event) {
    debugger;
    var strTagText = $("#tagtext").val();
    if ($("#tagtext").val().length > 1) {
        $.ajax({
            type: 'POST',
            url: '/Attachment/GetTags',
            dataType: "json",
            data: { str: strTagText },
            success: function (data) {
                var tags = data
                if (tags != []) {
                    $('#tags').tagSelector(tags, 'tags');
                }

            }
        });
    }
});

$.fn.tagSelector = function (source, name) {
    return this.each(function () {
        var selector = $(this),
            input = $('input[id="tagtext"]', this);
        input.keydown(function (e) {
            if (e.keyCode === $.ui.keyCode.TAB && $(this).data('autocomplete').menu.active)
                e.preventDefault();
        })
            .autocomplete({
                minLength: 1,
                //source:source,
                source: function (request, response) {
                    response($.map(source.tags, function (item) {
                        return {
                            value: item.Value,
                            id: item.Key
                        }
                    }));
                },
                focus: function () {
                    // prevent value inserted on focus
                    return false;
                },
                select: function (event, ui) {
                    var flagAlreadyExist = false;
                    $("#tags span.tag").each(function (index, elem) {
                        if ($(this).find("input").val() == ui.item.id)
                            flagAlreadyExist = true;
                    });
                    if (flagAlreadyExist == false) {
                        $("#TagID").val(ui.item.id);
                        $("#TagName").val(ui.item.value);
                        return true;
                    }

                }

            });
    });
};

function setSelected(liName)
{
    $("#" + liName).addClass('selected');
}

function AddNewValue(typeName, valueName, controlId, columnName, isAutoComplete, textboxId, textboxValue) {
    $('#lblError').addClass('hide')
    debugger;
    $("#lblOtherValue").text('');
    $("#txtOtherValue").val('');
    $("#lblOtherValue").text(valueName);
    $('#dvOtherValue').removeClass('hide').dialog({

        title: 'Add New ' + valueName,
        autoOpen: true,
        modal: true,
        draggable: true,
        width: 400,
        height: 'auto',
        buttons: [
            {
                text: "Save",
                "class": 'btn btn-success',
                click: function () {
                    if ($("#txtOtherValue").val() == "") {
                        $("#lblError").removeClass('hide');
                        return;
                    }
                    debugger;
                    var args = '"typeTable":' + '"' + typeName + '"' + ',' + '"value":' + '"' + $("#txtOtherValue").val() + '"' + ',' + '"columnName":' + '"' + columnName + '"' + ',' + '"controlId":' + '"' + controlId + '"';
                    var loc = '/Common/AddNewValue';

                    $.ajax({
                        type: 'POST',
                        url: loc,
                        data: '{' + args + '}',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {

                            if (isAutoComplete) {
                                //alert(response);
                                var option = '';
                                dataList = document.getElementById(textboxValue);
                                var option = document.createElement('option');
                                option.value = $("#txtOtherValue").val();
                                dataList.appendChild(option);
                                //option += '<option value="' + $("#txtOtherValue").val() + '" />';
                                //document.getElementById(textboxValue).innerHTML = option;
                                $("#" + textboxId).val($("#txtOtherValue").val());
                                $("#" + controlId).val(response.id);
                                // $("#" + textboxId).val(response.id);
                            }
                            else {
                                $("#" + controlId).append($('<option></option>').val(response.id).html($("#txtOtherValue").val()));
                                $("#" + controlId).val(response.id);
                            }
                            $("#lblOtherValue").text('');
                            $("#txtOtherValue").val('');
                        },
                        fail: function (response) { }
                    });
                    $("#dvOtherValue").addClass('hide').dialog("destroy");
                }},
                {
                    text: "Cancel",
                    "class": 'btn btn-danger',
                    click: function () {
                        $("#dvOtherValue").addClass('hide').dialog("destroy");
                    }
                }
        ]
    });
}
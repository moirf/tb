// This function add the new row of the table as well as bind all the event of the row 
//Please decalre the i=1; variable in document.ready   
function fn_AddNewRowWithClone(obj, strfnDeleteName) {
    debugger
    var tbId = $(obj).closest('table').attr('id');
    var row = $("#" + tbId + ">> tr:last").clone(); //get the clone row.
    var newRatingId = "";

    // This loop blank the value of text hidden field and selectedid or generate the new id,name for existing id,name 
    $(row).find(":input,.cssRating").each(function () {
        var type = this.type;

        var tag = this.tagName.toLowerCase(); // normalize case
       
        $(this).val('');
        $(this).removeClass("clserror");
        $(this).removeAttr('disabled');
      
        $(this).attr({
            'id': function (_, id) {
                if (id != '' && id != undefined) {
                    var ArrayId = id.split("-");
                    //var lastel = ArrayId[ArrayId.length - 1];
                    //debugger
                    //if ($.isNumeric(lastel)) { lastel = parseInt(lastel) + 1; } else { lastel=lastel + i; }
                    id = ArrayId[0] + "-" + i;
                    newRatingId = id;
                    return id
                }
            },
            'name': function (_, name) { if (name != '' && name != undefined) return name + i },
            'value': ''
        });

        

        //now unchecked the checkbox radio button.
        if (type == 'checkbox' || type == 'radio') {

            this.checked = false;
        }

        //now select the -1 for drop down list.
        if (tag == 'select') {
            this.selectedIndex = 0;
        }


    });

  
    //this will remove the + icon on the table 
    $("#" + tbId + ">> tr").find("a > i.glyphicon-plus").closest('a').remove();
    $("#" + tbId + ">> tr").find("a > span > i.glyphicon-plus").closest('a').remove();

    //This will blank the last td of clone row
    $(row).find("td:last").html('');


    if (typeof strfnDeleteName === 'undefined') {
        $(row).find("td:last").append($('<a href="javascript:void(0);" class="lnkActions"  onclick="fn_DeleteRow(this);"><i class="glyphicon glyphicon-trash"></i></a>&nbsp;&nbsp;<a href="javascript:void(0);" class="lnkActions" onclick="javascript:return fn_AddNewRowWithClone(this);"><span><i class="glyphicon glyphicon-plus"></i></span></a>'));
    }
    else {
        $(row).find("td:last").append($('<a href="javascript:void(0);" class="lnkActions"  onclick="' + strfnDeleteName + '"><i class="glyphicon glyphicon-trash"></i></a>&nbsp;&nbsp;<a href="javascript:void(0);" class="lnkActions" onclick=fn_AddNewRowWithClone(this)"); ><span><i class="glyphicon glyphicon-plus"></i></span></a>'));
    }

    $(row).find(".cssRating").html('');
   
    $("#" + tbId + " >tbody").append(row);// now will append the clone row to table.

    if ($(this).hasClass("cssRating")) {
    //    $("#" + newRatingId).empty();
        alert(newRatingId)
        $("#" + newRatingId).raty({ readOnly: true, score: 0 });
    }

    i++; //increment the counter variable.

  

}
//This function delete the temp row only clone which not add in DB.
//and add the + icon to the Last row in table 
function fn_DeleteRow(varobj) {
    var tbId = $(varobj).closest('table').attr('id');
    debugger
    var rowCount = $("#" + tbId + ">> tr").length;
    if (rowCount > 2) {
        $(varobj).closest('tr').remove();
        
        var perviousrow = $("#" + tbId + " >>tr:last");
        if (!($(perviousrow).find('td > a > i').hasClass("glyphicon-plus") || $(perviousrow).find('td > a > span > i').hasClass("glyphicon-plus"))) {
           // $(perviousrow).find("td:last").empty();
            $(perviousrow).find("td:last").append($('<a href="javascript:void(0);" class="lnkActions" onclick="javascript:return fn_AddNewRowWithClone(this);" ><span><i class="glyphicon glyphicon-plus"></i></span></a>'));
        }
    }
    else {
        alert('Please maintain atleast one row in grid.');
    }

}

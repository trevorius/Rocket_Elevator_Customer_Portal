console.log("testing Products")
var batterieForBuilding = [];
var columnForBatterie = [];
var elevatorForColumn = [];



//populate the divs
function populateBuildingDiv(){
    //prepend a title to the section
    $("<h6>Buildings</h6>").prependTo("#building-div");

    //each building gest its list item
    $.each(buildingList, function(i, building){
        var idString = `building-${i}`;
        $(`<li class="building-list-element" id=${idString}>${building.address_of_the_building}</li>`)
            .appendTo("#building-list");
    });
};
function populateBatterieDiv(buildingId){
    //prepend a title to the section
    $("#batterie-title").show(500);
    //remove all previous list elements
    $(".batterie-list-element").remove();
    batterieForBuilding = [];
    // reduce the batterie list to what is needed 
    $.each(batterieList, function(i,batterie){
        console.log(batterie)
        if (batterie.building_id == buildingId)
        {
            batterieForBuilding.push(batterie);
        }
    });
    console.log(batterieForBuilding)
    // add each batterie from final list to displayed list
    $.each(batterieForBuilding, function(i, batterie){
        var idString = `batterie-${i}`;
        $(`<li class="batterie-list-element" id=${idString}>number : ${batterie.id},</br> op certificate : ${batterie.operations_certificate}</li>`)
            .appendTo("#batterie-list");
    });
};
function populateColumnDiv(batterieId){

    $('<h6 id="column-title">Columns</h6>' +
        '<ul id="column-list">' +
        '</ul>')
        .appendTo("#column-div")


    //prepend a title to the section
    $("#column-title").show(500);
    //remove all previous list elements
    $(".column-list-element").remove();
    // reduce the column list to what is needed 
    columnForBatterie = [];
    $.each(columnList, function(i,column){
        console.log(column)
        if (column.battery_id == batterieId)
        {
            columnForBatterie.push(column);
        }
    });
    console.log(columnForBatterie)
    // add each column from final list to displayed list
    $.each(columnForBatterie, function(i, column){
        var idString = `column-${i}`;
        $(`<li class="column-list-element" id=${idString}>number : ${column.id},</br> in batterie : ${column.battery_id}</li>`)
            .appendTo("#column-list");
    });
};
function populateElevatorDiv(columnId){
        
    //prepend a title to the section
    $("#elevator-title").show(500);
    //remove all previous list elements
    $(".elevator-list-element").remove();
    // reduce the column list to what is needed 
    elevatorForColumn = [];
    $.each(elevatorList, function(i, elevator){
        console.log(elevator)
        if (elevator.column_id == columnId)
        {
            elevatorForColumn.push(elevator);
        }
    });
    console.log(elevatorForColumn)
    // add each column from final list to displayed list
    $.each(elevatorForColumn, function(i, elevator){
        var idString = `elevator-${i}`;
        $(`<li class="elevator-list-element" id=${idString}>number : ${elevator.id},</br> in column : ${elevator.column_id}</li>`)
            .appendTo("#elevator-list");
    });


};




// event handlers
function elevatorEvents(){
    $.each(elevatorForColumn,function(i, elevator){
        var BListId = `#elevator-${i}`;
        // on click color will change
        $(BListId).click(function(){
            //change the text back to black
            $(".elevator-list-element").css({"color": "black","background-color":"white","word-wrap":"break-word","padding":"5px"})
            //color the selected item
            $(BListId).css({"color":"blue", "background-color":"CornflowerBlue"})
            //display information in information div
            $("#information-display")
            .html("<h5>Elevator Information</h5>"+
               "<ul>" +
                    `<li>number : ${elevator.id}</li>` +
                    `<li>in column : ${elevator.column_id}</li>` +
                    `<li>building type: ${elevator.type_of_building}</li>` +
                    `<li>model: ${elevator.model}</li>` +
                    `<li>status : ${elevator.status}</li>` +
                    `<li>last inspection : ${elevator.last_inspection_date}</li>` +
                    `<li>certificate : ${elevator.inspection_certificate}</li>` +
                    `<li>information: ${elevator.information}</li>` +
                    `<li>notes: ${elevator.notes}</li>` +
                    `<li>comissioned on : ${elevator.commissioning_date}</li>` +
               "</ul>"   
            );

            //fill the preselctor table
            $("#elevator_id").val(elevator.id);


            //store elevator Id 
            var elevatorId = elevator.id;
            console.log(elevatorId);
            
            

        })
    });
};
function ColumnEvents(){
   $.each(columnForBatterie,function(i,column){
        var BListId = `#column-${i}`;
        // on click color will change
        $(BListId).click(function(){
            //change the text back to black
            $(".column-list-element").css({"color": "black","background-color":"white","word-wrap":"break-word","padding":"5px"})
            //color the selected item
            $(BListId).css({"color":"blue", "background-color":"CornflowerBlue"})
            //display information in information div
            $("#information-display")
            .html("<h5>Column Information</h5>"+
               "<ul>" +
                    `<li>number : ${column.id}</li>` +
                    `<li>in battery : ${column.battery_id}</li>` +
                    `<li>building type: ${column.type_of_building}</li>` +
                    `<li>status : ${column.status}</li>` +
                    `<li>number of floors served : ${column.number_of_floors_served}</li>` +
                    `<li>information: ${column.information}</li>` +
                    `<li>notes: ${column.notes}</li>` +
               "</ul>"   
            );

            //fill the preselctor table
            $("#column_id").val(column.id)
            $("#elevator_id").val(null);



            //store column Id to call api
            var columnId = column.id;
            console.log(columnId);
            populateElevatorDiv(columnId);
            elevatorEvents();

        })
    });                
};
function batteriEvents(){
    $.each(batterieForBuilding,function(i,batterie){
        var BListId = `#batterie-${i}`;
        // on click color will change
        $(BListId).click(function(){

            //change the text back to black
            $(".batterie-list-element").css({"color": "black","background-color":"white","word-wrap":"break-word","padding":"5px"})
            //color the selected item
            $(BListId).css({"color":"blue", "background-color":"CornflowerBlue"})
            //display information in information div
            $("#information-display")
            .html("<h5>Battery Information</h5>"+
               "<ul>" +
                    `<li>number : ${batterie.id}</li>` +
                    `<li>in building : ${batterie.building_id}</li>` +
                    `<li>building type: ${batterie.type_of_building}</li>` +
                    `<li>status : ${batterie.status}</li>` +
                    `<li>Technician id : ${batterie.employee_id}</li>` +
                    `<li>information: ${batterie.information}</li>` +
                    `<li>notes: ${batterie.notes}</li>` +
                    `<li>last inspection: ${batterie.last_inspection_date}</li>` +


               "</ul>"   
            );

            //empty irrelevent fields

                            $("#column-div").empty();


            
            $(".elevator-list-element").remove();
            $("#elevator-title").hide();
            $("#column_id").val(null)
            $("#elevator_id").val(null);


            //fill the preselctor table
            $("#battery_id").val(batterie.id)


            //store batterie Id to call api
            var batteriId = batterie.id;
            console.log(batteriId);
            populateColumnDiv(batteriId);
            ColumnEvents();

        })
    });                
};
function buildingEvents(){
    $.each(buildingList,function(i,building){
        var ListId = `#building-${i}`;
        // on click color will change
        $(ListId).click(function(){
            $("#batterie-div").find(".batterie-list-element").remove();
            //change the text back to black
            $(".building-list-element").css({"color": "black","background-color":"white","word-wrap":"break-word","padding":"5px"})
            //color the selected item
            $(ListId).css({"color":"blue", "background-color":"CornflowerBlue"})
            //display information in information div
            $("#information-display")
            .html("<h5>Building Information</h5>"+
               "<ul>" +
                    `<li>address : ${building.address_of_the_building}</li>` +
                    `<li>building administrator : ${building.full_name_of_the_building_administrator}</li>` +
                    `<li>administrator phone : ${building.phone_number_of_the_building_administrator}</li>` +
                    `<li>Technical contact : ${building.full_name_of_the_technical_contact_for_the_building}</li>` +
                    `<li>Technician phone : ${building.technical_contact_email_for_the_building}</li>` +
                    `<li>Technician email : ${building.technical_contact_phone_for_the_building}</li>` +
               "</ul>"   
            );
            //empty irrelevent fields
            $(".batterie-list-element").remove();

            $("#column-div").empty();
            //$(".column-list-element").remove();

            $("#column-title").hide();
            $(".elevator-list-element").remove();
            $("#elevator-title").hide();

            $("#column_id").val(null)
            $("#elevator_id").val(null);
            $("#battery_id").val(null)

            //fill the selector table for intervention form
            $("#building_id").val(building.id)
            //store Buidling Id to call api
            var buildingId = building.id;
            console.log(buildingId);
            populateBatterieDiv(buildingId);
            batteriEvents();
    
        })
    });

};




//DOM READY
$(function(){

    $("#customer_id").val(customerclass.id);

    // hide stuff and give it some STYLE
    $(".elevator-list-element").css({"color": "black","background-color":"white","word-wrap":"break-word","padding":"5px"})
    $("#column-title").hide();
    $("#batterie-title").hide();
    $('#elevator-title').hide();
    $("#information-display").css({"background-color":"mistyRose"});

    populateBuildingDiv();
    //start listening for events
    buildingEvents();

    
}); 
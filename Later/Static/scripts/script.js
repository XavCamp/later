$(function () {
    $('#openingTime').datepicker();

    $('#createButton').click(function () {
        // $(this).attr({disabled: true});
        
        var data = {
            openingTime: $('#openingTime').val(),
            message: $('#message').val()
        };

        console.log(data);

        $('#openingTime').toggleClass('formError', !data.openingTime);

        if(data.openingTime) {
            jQuery.post('api/capsules', data)
            .done(function () {
                console.log('plpo');
            })
            .fail(function () {
                console.log(arguments);
            });
            
        }
    });
});
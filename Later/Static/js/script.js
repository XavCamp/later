$(function () {

    var DateManager = (function () {
            
        var constructor = {};

        var _dateTime = moment();;

        var _$dateTimeDisplayer = $('#dateTimeDisplayer');

        constructor.updateDateTime = function () {
            _dateTime = moment($('#openingDay').datepicker("getDate")).hour($('#openingTime').val());
            constructor.updateDisplay();
        };

        constructor.updateDisplay = function () {
            $('#dayDisplayer').html(_dateTime.format('dddd'));
            $('#timeDisplayer').html(_dateTime.format('HH:mm'));
            $('#timezoneDisplayer').html(_dateTime.format('zz'));
        }

        constructor.getDateTime = function () {
            return moment(_dateTime);
        };

        constructor.setDateTime = function (dateTime) {
            _dateTime = moment(dateTime);
            constructor.updateDisplay();
            $('#openingDay').datepicker("setDate", _dateTime.toDate());
            $('#openingTime').val(_dateTime.hour());
        };

        return constructor;
    })();

    $('#openingDay').datepicker({
        dateFormat: "dd/mm/yy"
    });

    $('#openingDay, #openingTime').on('change', function () {
        DateManager.updateDateTime();
    });

    $('#tomorrowLink').click(function () {
        DateManager.setDateTime(moment().add('days', 1));
    });

    $('#createButton').click(function () {
        // $(this).attr({disabled: true});
        
        var data = {
            Deadline: DateManager.getDateTime().toISOString(),
            Message: $('#message').val() || 'empty'
        };

        console.log(data);

        if(data.Deadline) {
            jQuery.ajax({
                type: 'POST',
                url: 'api/capsules',
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
            }).done(function (response) {
                console.log(response);
            }).fail(function () {
                console.log(arguments);
            });
            
        }
    });

    DateManager.setDateTime(new Date());
});
/*
Developed By: Pijush Biswas
Pre-Requisites : Must has Microsoft Chart Installed on Server Side / MVC3 
Have a controller, prefereably with Chart name
Have a action Name, preferably with Graph name
Method Signature :  
*/
(function ($) {
    var defaults = {
        url: url = "/Chart/Graph/0?width=600&height=400",
        loading: 'loading..',
        success: function (data) {
        }
    };
    $.fn.graph = function (type, options) {
        var settings = $.extend({}, defaults, options);
        //Now I support only one
        var pie = function (element) {
            var chartImage = $("<img class='dyn_img' alt='chart'/>").attr("src", settings.url);
            $(element).append(chartImage);
            if (settings.success) {
                settings.success(chartImage);
            }
            return chartImage;
        };
        var graph = function (element) {
            $.ajax(
                {
                    url: settings.url,
                    type: "POST",
                    data: settings.data,
                    success: function (data) {
                        var chartImage = $("<img class='dyn_img' alt='chart'/>").attr("src", "data:image/png;base64,'" + data + "'");
                        $(element).append(chartImage);
                        if (settings.success) {
                            settings.success(chartImage);
                        }
                        return chartImage;
                    }
                });
            return element;
        };
        try {
            $(this).empty();
            if (type == "pie" || settings.type == "pie") {
                return pie($(this), settings);
            }
            else if (type == "chart") {
              return   graph($(this));
            }

        }
        catch (ex) {
            if (settings.error) {
                settings.error(ex);
            }
        }
        return this;
    };

})(jQuery);
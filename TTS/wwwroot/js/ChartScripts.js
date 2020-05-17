var pieChart;
var ProfileChart;
function Load() {
    var oilCanvas = document.getElementById("allprojecttimeChart");
    var lables = [];
    var dataset = [];
    Chart.defaults.global.defaultFontFamily = "Lato";
    Chart.defaults.global.defaultFontSize = 18;
    $.getJSON("/Analysis/GetAllProjectInfo", { id: 2}, function (data) {
        $.each(data, function (key, val) {
            lables.push(key);
            dataset.push(val);
        });
        var data_project = {
            labels: lables,
            datasets: [
                {
                    data: dataset,
                    backgroundColor: [
                        "#FF6384",
                        "#63FF84",
                        "#84FF63",
                        "#8463FF",
                        "#6384FF"
                    ]
                }]
        };
        pieChart = new Chart(oilCanvas, {
            type: 'pie',
            data: data_project,
            options: {
                showDatasetLabels: true,
                responsive: true,
                maintainAspectRatio: false,
                legend: {
                    labels: {
                        // This more specific font property overrides the global property
                        fontColor: 'white'
                    }
                }
            }
        });
    });
}
$("#allprojecttimeChart").click(function (event) {
    var activePoints = pieChart.getElementsAtEvent(event);
    if (activePoints[0]) {
        var chartData = activePoints[0]['_chart'].config.data;
        var idx = activePoints[0]['_index'];

        var label = chartData.labels[idx];
        var value = chartData.datasets[0].data[idx];

        var url = "http://example.com/?label=" + label + "&value=" + value;
        GetInfoProject(label);
    }
})
function GetInfoProject(project) {
    var lables = [];
    var dataset = [];
    $.getJSON("/Analysis/GetProjectInfo", { project: project }, function (data) {
        $.each(data, function (key, val) {
            lables.push(key);
            dataset.push(val);
        });
        var data_project = {
            labels: lables,
            datasets: [
                {
                    data: dataset,
                    backgroundColor: [
                        "#FF6384",
                        "#63FF84",
                        "#84FF63",
                        "#8463FF",
                        "#6384FF"
                    ]
                }]
        };
        var canvas = $("#projectTimeChart");
        if (ProfileChart != null) {
            ProfileChart.destroy();
        }
        ProfileChart = new Chart(canvas, {
            type: 'pie',
            data: data_project,
            options: {
                showDatasetLabels: true,
                responsive: true,
                maintainAspectRatio: false,
                legend: {
                    labels: {
                        // This more specific font property overrides the global property
                        fontColor: 'white'
                    }
                }
            }
        });
    });
}
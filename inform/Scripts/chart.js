$(function () {
    // Load the fonts
    Highcharts.createElement('link', {
        href: '//fonts.googleapis.com/css?family=Unica+One',
        rel: 'stylesheet',
        type: 'text/css'
    }, null, document.getElementsByTagName('head')[0]);

    Highcharts.theme = {
        colors: ["#2b908f", "#90ee7e", "#f45b5b", "#7798BF", "#aaeeee", "#ff0066", "#eeaaee",
           "#55BF3B", "#DF5353", "#7798BF", "#aaeeee"],
        chart: {
            backgroundColor: {
                linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                stops: [
                   [0, '#2a2a2b'],
                   [1, '#3e3e40']
                ]
            },
            style: {
                fontFamily: "'Unica One', sans-serif"
            },
            plotBorderColor: '#606063'
        },
        title: {
            style: {
                color: '#E0E0E3',
                textTransform: 'uppercase',
                fontSize: '20px'
            }
        },
        subtitle: {
            style: {
                color: '#E0E0E3',
                textTransform: 'uppercase'
            }
        },
        xAxis: {
            gridLineColor: '#707073',
            labels: {
                style: {
                    color: '#E0E0E3'
                }
            },
            lineColor: '#707073',
            minorGridLineColor: '#505053',
            tickColor: '#707073',
            title: {
                style: {
                    color: '#A0A0A3'

                }
            }
        },
        yAxis: {
            gridLineColor: '#707073',
            labels: {
                style: {
                    color: '#E0E0E3'
                }
            },
            lineColor: '#707073',
            minorGridLineColor: '#505053',
            tickColor: '#707073',
            tickWidth: 1,
            title: {
                style: {
                    color: '#A0A0A3'
                }
            }
        },
        tooltip: {
            backgroundColor: 'rgba(0, 0, 0, 0.85)',
            style: {
                color: '#F0F0F0'
            }
        },
        plotOptions: {
            series: {
                dataLabels: {
                    color: '#B0B0B3'
                },
                marker: {
                    lineColor: '#333'
                }
            },
            boxplot: {
                fillColor: '#505053'
            },
            candlestick: {
                lineColor: 'white'
            },
            errorbar: {
                color: 'white'
            }
        },
        legend: {
            itemStyle: {
                color: '#E0E0E3'
            },
            itemHoverStyle: {
                color: '#FFF'
            },
            itemHiddenStyle: {
                color: '#606063'
            }
        },
        credits: {
            style: {
                color: '#666'
            }
        },
        labels: {
            style: {
                color: '#707073'
            }
        },

        drilldown: {
            activeAxisLabelStyle: {
                color: '#F0F0F3'
            },
            activeDataLabelStyle: {
                color: '#F0F0F3'
            }
        },

        navigation: {
            buttonOptions: {
                symbolStroke: '#DDDDDD',
                theme: {
                    fill: '#505053'
                }
            }
        },

        // scroll charts
        rangeSelector: {
            buttonTheme: {
                fill: '#505053',
                stroke: '#000000',
                style: {
                    color: '#CCC'
                },
                states: {
                    hover: {
                        fill: '#707073',
                        stroke: '#000000',
                        style: {
                            color: 'white'
                        }
                    },
                    select: {
                        fill: '#000003',
                        stroke: '#000000',
                        style: {
                            color: 'white'
                        }
                    }
                }
            },
            inputBoxBorderColor: '#505053',
            inputStyle: {
                backgroundColor: '#333',
                color: 'silver'
            },
            labelStyle: {
                color: 'silver'
            }
        },

        navigator: {
            handles: {
                backgroundColor: '#666',
                borderColor: '#AAA'
            },
            outlineColor: '#CCC',
            maskFill: 'rgba(255,255,255,0.1)',
            series: {
                color: '#7798BF',
                lineColor: '#A6C7ED'
            },
            xAxis: {
                gridLineColor: '#505053'
            }
        },

        scrollbar: {
            barBackgroundColor: '#808083',
            barBorderColor: '#808083',
            buttonArrowColor: '#CCC',
            buttonBackgroundColor: '#606063',
            buttonBorderColor: '#606063',
            rifleColor: '#FFF',
            trackBackgroundColor: '#404043',
            trackBorderColor: '#404043'
        },

        // special colors for some of the
        legendBackgroundColor: 'rgba(0, 0, 0, 0.5)',
        background2: '#505053',
        dataLabelsColor: '#B0B0B3',
        textColor: '#C0C0C0',
        contrastTextColor: '#F0F0F3',
        maskColor: 'rgba(255,255,255,0.3)'
    };

    // Apply the theme
    Highcharts.setOptions(Highcharts.theme);

    $('#chart').highcharts({
        chart: {
            type: 'spline'
        },
        title: {
            text: 'Progression'
        },
        subtitle: {
            text: 'Ronaldos performance'
        },
        xAxis: {
            type: 'datetime',
            labels: {
                overflow: 'justify'
            }
        },
        yAxis: {
            title: {
                text: 'Performance percentage * 10'
            },
            minorGridLineWidth: 0,
            gridLineWidth: 0,
            alternateGridColor: null,
            plotBands: [{ 
                from: 0,
                to: 5,
                color: 'rgba(0, 0, 0, 0)',
                label: {
                    text: 'Bad form',
                    style: {
                        color: '#DADADA'
                    }
                }
            }, {
                from: 5,
                to: 8,
                color: 'rgba(68, 170, 213, 0.1)',
                label: {
                    text: 'Form Below average',
                    style: {
                        color: '#DADADA'
                    }
                }
            }, { 
                from: 8,
                to: 9,
                color: 'rgba(0, 0, 0, 0)',
                label: {
                    text: 'Decent form',
                    style: {
                        color: '#DADADA'
                    }
                }
            }, { 
                from: 9,
                to: 10,
                color: 'rgba(68, 170, 213, 0.1)',
                label: {
                    text: 'Good form',
                    style: {
                        color: '#DADADA'
                    }
                }
            }, { 
                from: 10,
                to: 11,
                color: 'rgba(0, 0, 0, 0)',
                label: {
                    text: 'Very good form',
                    style: {
                        color: '#DADADA'
                    }
                }
            }, { 
                from: 11,
                to: 12,
                color: 'rgba(68, 170, 213, 0.1)',
                label: {
                    text: 'Ballon dOr',
                    style: {
                        color: '#DADADA'
                    }
                }
            }]
        },
        tooltip: {
            valueSuffix: '*10 = %'
        },
        plotOptions: {
            spline: {
                lineWidth: 4,
                states: {
                    hover: {
                        lineWidth: 5
                    }
                },
                marker: {
                    enabled: false
                },
                pointInterval: 1000000000, // one hour
                pointStart: Date.UTC(2015, 7, 23, 0, 0, 0)
            }
        },
        series: [{
            name: 'Avg. form throughout Real Madrid career',
            data: [7, 7, 7.6, 7.3, 7.7, 8, 7, 8.9, 7.9, 8, 8.6, 9, 9.1, 9.2, 9.5, 9.7, 8.9, 9, 10.6, 10.1, 10.7, 10, 9.7, 9.8, 10.1, 10.2, 10.2, 9.9, 10.1, 10.4, 10, 9.6, 8.2, 8, 8.2, 7.5, 7.6, 7.1, 7, 7.3, 8, 9, 9.8, 10.6, 10.8, 10.7, 10.8, 11, 11]

        }, {
            name: 'So far current season',
            data: [8, 8.2, 7.6, 7.9, 8, 8.2, 8, 8.1, 8.3, 8.1, 8.4, 8.5, 8.6, 8.4, 8.8, 9.1, 9, 9.3, 10.1, 9.9, 10.1, 10.4, 10.7, 9, 9.5, 9.4, 9, 8.3, 8, 7.8, 8.2, 8.1, 8.3, 7.3, 8, 9.1, 9.1, 9.5, 9.5, 9.9, 10.6, 10.9, ]
        }],
        navigation: {
            menuItemStyle: {
                fontSize: '10px'
            }
        }
    });



});
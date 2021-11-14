<template>
  <div v-if="measurements">
    <DayChart :measurements="measurements" :options="options" />
  </div>
</template>

<script>
import DayChart from './components/DayChart.vue'
import M from 'materialize-css'
//import MonthChart from './components/MonthChart.vue'

export default {
  name: 'App',
  components: {
    DayChart,
  //  MonthChart
  },
  // provide: {
  //   user: 'John Doe'
  // },
  created() {
     this.getData()
  },
    data() {
    return  {
        loading : false,
        measurements: [],
        options: {
                id: 'Cumulative',
                legend: {
                    display: false
                },
                scales: {
                    xAxes: [{
                        type: 'time',
                        distribution: 'series',
                        time: {
                            displayFormats: {
                                millisecond: 'mm:ss:SS',
                                quarter: 'MMM YYYY'
                            }
                        }
                    }],
                    yAxes: [{
                        ticks: {
                            //beginAtZero: true
                        }
                    }]
                }
        }
    }
  },
  mounted() {
    M.AutoInit()
  },
    methods: {
      getData() {
        fetch('https://airquality-api.azurewebsites.net/api/AirQualityApiHttpTrigger')
        .then(result => result.json())
        .then(results => {
            //.measurements = data;
            console.log(results);
            // var resultTimestamps = results.map(i => i.timestamp);
            // var resultPM25 = results.map(i =>  parseFloat(i.pM25).toFixed(2));
            // var resultsPM10 = results.map(i => parseFloat(i.pM10).toFixed(2));

            this.measurements = results.reverse();
            // this.dataCollection = {
            //     // labels: ['lol'], 
            //     // datasets: []
            //     labels: resultTimestamps,
            //     datasets: [
            //         {
            //         label: "PM2.5",
            //         data: resultPM25,
            //         backgroundColor: ['#77CEFF'],
            //         },
            //         {
            //         label: "PM10",
            //         data: resultsPM10,
            //         backgroundColor: ['#0079AF'],
            //         },
            //     ]
            // }
            this.loading = false;
        })
        .catch(err => {
            console.log(err.message)
            this.loading = false;
        })
      }
}
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>

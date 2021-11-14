<template>
  <div class='container'> 
      <table>
          <thead>
          <tr>
              <th>Czas</th>
              <th>PM25</th>
              <th>PM10</th>
          </tr>
        </thead>
        <tr  v-for="(item, index) in measurements" :key="index">
           <td> {{ new Date(item.timestamp).toLocaleString('pl-PL', { timeZone: 'Europe/Warsaw' }) }}</td>
           <td> {{ item.pM25 }}</td>
           <td> {{ item.pM10 }}</td>
        </tr>
     </table>
    <!-- <LineChart :chartData="dataCollection" :options="options"  /> -->
    <!-- <LineChart :chartData="dataCollection" :options="options"  v-if="!loading" /> -->
  </div>
</template>

<script lang="ts">


import { defineComponent} from "vue";
// import { LineChart } from 'vue-chart-3';

export default defineComponent({
  name: 'DailyChart',
//   inject: ['dataCollection', 'options'],
//   created() {
//     console.log(`Injected property: ${this.dataCollection}`) // > Injected property: John Doe
//   },
//   components: { LineChart },
    props: { 
            measurements: {},
            options: {}
    },
  mounted() {
    // this.fillData()
  },
  setup() {
      //async setup() {
        // let data = await fetch('https://airquality-api.azurewebsites.net/api/AirQualityApiHttpTrigger')
        // .then(result => result.json())
        // .then(results => ({
        //   chartData: {
        //     labels: results.map(i => i.date),
        //     datasets: [
        //       {
        //         label: "PM2.5",
        //         data: results.map(i => i.pM25),
        //         backgroundColor: ['#77CEFF'],
        //       },
        //       {
        //         label: "PM10",
        //         data: results.map(i => i.pM10),
        //         backgroundColor: ['#0079AF'],
        //       },
        //     ]
        //   }
        // }))
        // .catch(err => console.log(err.message))

        // return { 
        //     dataCollection: data,
        //     loading: false
        // }
  }
});
</script>


<style>
  .container {
    max-width: 800px;
    margin: 0 auto;
  }
  h1 {
    font-family: 'Helvetica', Arial;
    color: #464646;
    text-transform: uppercase;
    border-bottom: 1px solid #f1f1f1;
    padding-bottom: 15px;
    font-size: 28px;
    margin-top: 0;
  }
  .Chart {
    padding: 20px;
    box-shadow: 0px 0px 20px 2px rgba(0, 0, 0, .4);
    border-radius: 20px;
    margin: 50px 0;
  }
</style>
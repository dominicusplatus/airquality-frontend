<template>
  <div class='container'> 
  <LineChart  v-bind="displayData"  />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { LineChart } from 'vue-chart-3';

export default defineComponent({
  name: 'Home',
  components: { LineChart },
  data() {
    return {
      measurements: [],
      displayData: {}
    }
  },
  mounted() {
    fetch('https://airquality-api.azurewebsites.net/api/AirQualityApiHttpTrigger')
    .then(result => result.json())
    .then(data => {
      this.measurements = data;
      this.displayData = {
        datasets: [
          {
            data: this.measurements
          },
        ]
      }
    })
    .catch(err => console.log(err.message))
  },
  setup() {

  },
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
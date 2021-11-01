<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <div>
      <canvas id="myChart"></canvas>
    </div>
  </div>
</template>

<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

<script>

    const config = {
      type: 'line',
      data: data,
      options: {}
    };

    const labels = [
      'January',
      'February',
      'March',
      'April',
      'May',
      'June',
    ];
    const data = {
      labels: labels,
      datasets: [{
        label: 'My First dataset',
        backgroundColor: 'rgb(255, 99, 132)',
        borderColor: 'rgb(255, 99, 132)',
        data: [0, 10, 5, 2, 20, 30, 45],
      }]
    };

    const myChart = new Chart(
      document.getElementById('myChart'),
      config
    );

  export default {
    name: 'HelloWorld',
    props: {
      msg: String
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>

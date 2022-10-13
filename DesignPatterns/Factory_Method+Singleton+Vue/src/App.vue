<script setup lang="ts">
import HelloWorld from "./components/HelloWorld.vue";
</script>

<template>
  <div>
    <div>
      <iframe
        width="560"
        height="315"
        src="https://www.youtube.com/embed/ll4JR_WEeNs"
        title="YouTube video player"
        frameborder="0"
        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
        allowfullscreen
      ></iframe>
    </div>
    <a href="https://vitejs.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="./assets/vue.svg" class="logo vue" alt="Vue logo" />
    </a>
    <a
      href="https://www.youtube.com/channel/UCXyx4LyjmuFEWqcg_agU2Ig"
      target="_blank"
    >
      <img src="./assets/lacdi.png" class="logo vue" alt="Vue logo" />
    </a>
  </div>
  <HelloWorld msg="Vite + La Cueva del Insecto + Vue" />
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>

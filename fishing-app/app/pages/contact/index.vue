<script setup lang="ts">
import { Icon } from "@iconify/vue";
</script>

<template>
  <v-container class="mt-8 mb-16">
    <h1 class="text-center mb-12">Skontaktuj się z nami</h1>
    <v-row>
      <h2 class="text-h5 mb-4">Wędkarski Świat - sprzet jest i nawet dziala</h2>
      <p class="mb-6">
        Jesteśmy grupą pasjonatów, dla których wędkarstwo to coś więcej niż
        tylko hobby – to styl życia. Od ponad dekady dostarczamy wędkarzom w
        całej Polsce najwyższej klasy sprzęt, który sprawdza się zarówno podczas
        weekendowych wypadów nad jezioro, jak i na profesjonalnych zawodach.
        Naszą misją jest szerzenie wiedzy, promowanie zasady "złów i wypuść"
        oraz dostarczanie produktów, na których możesz polegać w każdych
        warunkach. Ale ai zapodało tekstem niezle, poeta normalny.
      </p>
      <div class="d-flex">
        <Icon
          icon="mdi:phone-in-talk"
          width="32"
          height="32"
          class="text-orange-darken-3 mr-4"
        />
        <div>
          <h3>Zadzwoń do nas</h3>
          <p>+48 123 456 789</p>
        </div>
      </div>
      <div class="d-flex">
        <Icon
          icon="mdi:email"
          width="32"
          height="32"
          class="text-orange-darken-3 mr-4"
        />
        <div>
          <h3>Wyślij maila</h3>
          <p>kontakt@wedkarskiswiat.pl</p>
        </div>
      </div>
    </v-row>
  </v-container>
</template>

<style scoped>
h3 {
  padding: 0;
  margin: 0;
}
p {
  padding: 0;
  margin: 0;
  color: #666;
}
</style>

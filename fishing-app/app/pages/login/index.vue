<script setup lang="ts">
import { ref } from "vue";
const form = ref();
const email = ref("");
const password = ref("");
const emailRules = [
  (v: string) => !!v || "Email is required",
  (v: string) => /.+@.+\..+/.test(v) || "Email must be valid",
];
const passwordRules = [
  (v: string) => !!v || "Password is required",
  (v: string) => v.length >= 6 || "Password must be at least 6 characters",
];
const handleLogin = async () => {
  const isValid = await form.value.validate();
  if (isValid) {
    // Handle login logic here
    console.log("Email:", email.value);
    console.log("Password:", password.value);
  } else {
    console.log("Form is invalid");
  }
};
</script>

<template>
  <v-sheet class="mx-auto" width="300">
    <v-form ref="form" fast-fail @submit.prevent="handleLogin">
      <v-text-field
        v-model="email"
        :rules="emailRules"
        label="Email"
      ></v-text-field>

      <v-text-field
        v-model="password"
        :rules="passwordRules"
        label="Password"
        type="password"
      ></v-text-field>

      <v-btn class="mt-2" type="submit" block>Submit</v-btn>
    </v-form>
  </v-sheet>
</template>

<script>
export default {
  data: () => ({
    valid: false,
    email: "",
    password: "",
    passwordConfirm: "",
    emailRules: [
      (value) => !!value || "E-mail is required.",
      (value) => /.+@.+\..+/.test(value) || "E-mail must be valid.",
    ],
    passwordRules: [
      (value) => !!value || "Password is required.",
      (value) =>
        (value && value.length <= 10) ||
        "Password must be 10 characters or less.",
    ],
    // ADDED THIS:
    passwordConfirmRules: [
      (value) => !!value || "Confirm Password is required.",
      (value, instance) =>
        value === instance.password || "Passwords must match.",
    ],
  }),
};
function test() {
  alert("Form submitted!");
}
</script>

<template>
  <v-form v-model="valid">
    <v-container>
      <h1>Creating new account</h1>

      <!-- Use v-row instead of div for Vuetify columns -->
      <v-row class="flex flex-column border-thin rounded-lg p-4 bg-grey-lighten-1 text-center max-w-sm">
        <v-col cols="12" md="4">
          <v-text-field
            v-model="email"
          
            :rules="emailRules"
            label ="E-mail"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field
            v-model="password"
            type="password"
            :counter="10"
            :rules="passwordRules"
            label="Password"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field
            v-model="passwordConfirm"
            type="password"
            :counter="10"
            :rules="passwordConfirmRules"
            label="Confirm Password"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12">
          <v-btn :disabled="!valid" color="primary" @click="test">Submit</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
</template>

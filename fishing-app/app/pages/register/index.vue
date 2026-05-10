<script setup lang="ts">
import { Icon } from "@iconify/vue";
const valid = ref(false);
const email = ref("");
const password = ref("");
const passwordConfirm = ref("");

//icons event handling

const emailIcon= ref(false)
const passwordIcon= ref(false)
const passwordConfirmIcon= ref(false)

//change avlidation to ts standard
    password: ""
    passwordConfirm: ""
    emailRules: [
      (value) => !!value || "E-mail is required.",
      (value) => /.+@.+\..+/.test(value) || "E-mail must be valid.",
    ]
    passwordRules: [
      (value) => !!value || "Password is required.",
      (value) =>
        (value && value.length <= 10) ||
        "Password must be 10 characters or less.",
    ]
    // ADDED THIS:
    passwordConfirmRules: [
      (value) => !!value || "Confirm Password is required.",
      (value, instance) =>
        value === instance.password || "Passwords must match.",
    ]

function test() {

  alert("Form submitted!");
}
function icon1(){
  alert("Icon clicked!111");
  
  if(emailIcon.value === true){
    

  }
}
function icon2(){
  alert("Icon clicked!222");
  passwordIcon.value = true;
  if(passwordIcon.value === true){
    alert("Password icon is now true!");
  }
}
function icon3(){
  alert("Icon clicked!333");
  passwordConfirmIcon.value = true;
  if(passwordConfirmIcon.value === true){
    alert("Password Confirm icon is now true!");
  }

}
//Email Icon
//<Icon icon="streamline:send-email-solid" width="14" height="14" />
/* password icon
<Icon icon="solar:lock-password-bold" width="24" height="24" />
*/
</script>

<template>
  <v-form v-model="valid">

    <v-container>
      <h1>Creating new account</h1>

      <!-- Use v-row instead of div for Vuetify columns -->
      <v-row class="flex flex-column border-thin rounded-lg p-4 bg-grey-lighten-1 text-center max-w-sm">
        <v-col cols="12" md="4" >
          <v-text-field @click="icon1"
          
            v-model="email"
            :rules="emailRules"   
            label ="E-mail" 
            placeholder="Enter your e-mail"
            required  
           
            ><Icon icon="streamline:send-email-solid" width="14" height="14" /></v-text-field>
          
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field @click="icon2"
            v-model="password"
            type="password"
            :counter="10"
            :rules="passwordRules"
            label="Password"
            required
            
          ><Icon icon="solar:lock-password-bold" width="24" height="24" /></v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field @click="icon3"
            v-model="passwordConfirm"
            type="password"
            :counter="10"
            :rules="passwordConfirmRules"
            label="Confirm Password"
            required
             
          ><Icon icon="solar:lock-password-bold" width="24" height="24" /></v-text-field>
        </v-col>

        <v-col cols="12">
          <v-btn :disabled="!valid" color="primary" @click="test">Submit</v-btn>
        </v-col>
      </v-row>
    </v-container>  
  </v-form>
</template>

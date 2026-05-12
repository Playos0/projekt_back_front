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
  emailIcon.value = true
    
}
function icon2(){
  passwordIcon.value = true;
 
}
function icon3(){
  passwordConfirmIcon.value = true;
 

}
//Email Icon
//<Icon icon="streamline:send-email-solid" width="14" height="14" />
/* password icon
<Icon icon="solar:lock-password-bold" width="24" height="24" />
*/
</script>

<template v-slot:append-inner>
  <div class="d-flex flex-row fill-width fill-height">
  <div class=" bg-grey-lighten-1 height-max  height-full w-33">Boczny pasek</div>
  <div class="bg-black width-50">
  <v-form  v-model="valid">

    <v-container >
      <h1 class="text-center">Creating new account</h1>

      <!-- Use v-row instead of div for Vuetify columns -->
      <v-row class="flex flex-column border-thin rounded-lg p-4 text-center max-w-sm ma-2 bg-grey-lighten-5">
        <v-col cols="12" md="4" >
          <v-text-field @click="icon1"
          
            v-model="email"
            :rules="emailRules"   
            label ="E-mail" 
            placeholder="Enter your e-mail"
            required  
            @focus="emailIcon = true" 
            @blur="emailIcon = false"
           
            ><Icon
            v-if="emailIcon"
            icon="streamline:send-email-solid" width="14" height="14" /></v-text-field>
          
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field @click="icon2"
            v-model="password"
            type="password"
            :counter="10"
            :rules="passwordRules"
            label="Password"
            required
               @focus="passwordIcon = true" 
            @blur="passwordIcon = false"
            
          ><Icon
            v-if="passwordIcon"
            icon="solar:lock-password-bold" width="24" height="24" /></v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field @click="icon3"
            v-model="passwordConfirm"
            type="password"
            :counter="10"
            :rules="passwordConfirmRules"
            label="Confirm Password"
            required
             @focus="passwordConfirmIcon = true" 
            @blur="passwordConfirmIcon = false"
          ><Icon
            v-if="passwordConfirmIcon"
            icon="solar:lock-password-bold" width="24" height="24" /></v-text-field>
        </v-col>

        <v-col cols="12">
          <v-btn :disabled="!valid" color="primary" @click="test">Submit</v-btn>
        </v-col>
      </v-row>
    </v-container>  
  </v-form>
  </div>
  </div>
</template>

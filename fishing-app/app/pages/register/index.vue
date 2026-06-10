<script setup lang="ts">
import { ref } from 'vue'
import { Icon } from '@iconify/vue'

const valid = ref<boolean>(false)

interface AddressStructure {
  street: string
  houseNumber: string
  postalCode: string
  city: string
}

interface RegisterForm {
  name: string
  email: string
  password: string
  passwordConfirm: string
  address: AddressStructure
}

interface FormIconsState {
  name: boolean
  email: boolean
  password: boolean
  passwordConfirm: boolean
  address: Record<keyof AddressStructure, boolean>
  //keyof is forauto mapping the address fields to the icons state
}

// 1. data model
const form = ref<RegisterForm>({
  name: '',
  email: '',
  password: '',
  passwordConfirm: '',
  address: {
    street: '',
    houseNumber: '',
    postalCode: '',
    city: '',
  },
})

// icons in form fields
const Icons = ref<FormIconsState>({
  name: false,
  email: false,
  password: false,
  passwordConfirm: false,
  address: {
    street: false,
    houseNumber: false,
    postalCode: false,
    city: false,
  },
})
// Validation rules
const emailRules = [
  (value: string) => !!value || 'E-mail is required.',
  (value: string) => /.+@.+\..+/.test(value) || 'E-mail must be valid.',
]

const passwordRules = [
  (value: string) => !!value || 'Password is required.',
  (value: string) => (value && value.length <= 10) || 'Max 10 characters.',
]

const passwordConfirmRules = [
  (value: string) => !!value || 'Confirm Password is required.',
  // POPRAWKA: Odwołujemy się do hasła wewnątrz modelu `form.value`
  (value: string) => value === form.value.password || 'Passwords must match.',
]

const requiredRules = (fieldName: string) => [(value: string) => !!value || `${fieldName} is required.`]

const postalCodeRules = [
  (value: string) => !!value || 'Postal code is required.',
  (value: string) => /^\d{2}-\d{3}$/.test(value) || 'Postal code must be XX-XXX.',
]

async function test() {
  if (!valid.value) return

  // POPRAWKA: Dzięki modelowi danych nie musisz przepisywać każdego pola ręcznie!
  // Wyciągamy passwordConfirm (bo API go nie chce), a resztę (payload) wysyłamy.
  const { passwordConfirm, ...payload } = form.value

  try {
    const response = await $fetch('http://localhost:5004/api/Auth/register', {
      method: 'POST',
      body: payload,
    })
    alert('Account and address registered successfully!')
  } catch (error) {
    console.error('Registration error:', error)
    alert('An error occurred during registration.')
  }
}
</script>

<template>
  <div class="d-flex flex-row v-screen-height" style="height: 100vh"  >
    <div class="card-color d-none d-md-flex align-center justify-center" style="width: 30%">
      <div class=" bg-orange d-flex-row border-thin rounded-lg pa-6 text-center ">
        <h2 class="text-h3">Zobacz naszą ofertę subskrypcji!</h2>
        <nuxt-link to="/subscription" class="text-white flex-end">Kliknij tutaj!</nuxt-link>
        <div label="socials" class="gap-4 mt-6 d-flex align-center justify-center">
          <Icon icon="mdi:facebook" width="24" height="24" class="mr-2" />
          <Icon icon="mdi:twitter" width="24" height="24" class="mr-2" />
          <Icon icon="mdi:instagram" width="24" height="24" />
        </div>
      </div>
    </div>

    <div class="bg-black flex-grow-1 d-flex align-center justify-center overflow-y-auto">
      <v-form v-model="valid" style="width: 100%; max-width: 550px " class="bg-white rounded-lg ">
        <v-container>
<v-row class="flex-column border-thin rounded-lg pa-6 text-center ma-4 mt-16">          
  <h1 class="text-h4 mb-4">Creating new account</h1>

            <v-col cols="12" class="text-left pb-0">
              <span class="text-subtitle-2 font-weight-bold text-grey-darken-2">Account Details</span>
            </v-col>
            <v-col cols="12">
              <v-text-field
                v-model="form.name"
                :rules="requiredRules('Name')"
                label="Full Name"
                placeholder="Enter your full name"
                required
                @focus="Icons.name = true"
                @blur="Icons.name = false"
              >
                <template v-slot:append-inner>
                  <Icon v-if="Icons.name" icon="wpf:name" width="24" height="24" />
                </template>
              </v-text-field>
            </v-col>
            <v-col cols="12">
              <v-text-field
                v-model="form.email"
                :rules="emailRules"
                label="E-mail"
                placeholder="Enter your e-mail"
                required
                @focus="Icons.email = true"
                @blur="Icons.email = false"
              >
                <template v-slot:append-inner>
                  <Icon v-if="Icons.email" icon="streamline:send-email-solid" width="20" height="20" />
                </template>
              </v-text-field>
            </v-col>

            <v-col cols="12">
              <v-text-field
                v-model="form.password"
                type="password"
                :counter="10"
                :rules="passwordRules"
                label="Password"
                required
                @focus="Icons.password = true"
                @blur="Icons.password = false"
              >
                <template v-slot:append-inner>
                  <Icon v-if="Icons.password" icon="solar:lock-password-bold" width="24" height="24" />
                </template>
              </v-text-field>
            </v-col>

            <v-col cols="12">
              <v-text-field
                v-model="form.passwordConfirm"
                type="password"
                :counter="10"
                :rules="passwordConfirmRules"
                label="Confirm Password"
                required
                @focus="Icons.passwordConfirm = true"
                @blur="Icons.passwordConfirm = false"
              >
                <template v-slot:append-inner>
                  <Icon v-if="Icons.passwordConfirm" icon="solar:lock-password-bold" width="24" height="24" />
                </template>
              </v-text-field>
            </v-col>

            <v-divider class="my-2"></v-divider>

            <v-col cols="12" class="text-left pb-0">
              <span class="text-subtitle-2 font-weight-bold text-grey-darken-2">Address Information</span>
            </v-col>

            <v-col cols="12">
              <v-text-field
                v-model="form.address.street"
                :rules="requiredRules('Street')"
                label="Street"
                placeholder="e.g. Main Street"
                required
                @focus="Icons.address.street = true"
                @blur="Icons.address.street = false"
              >
                <template v-slot:append-inner>
                  <Icon v-if="Icons.address.street" icon="fluent-mdl2:street" width="24" height="24" />
                </template>
              </v-text-field>
            </v-col>

            <v-col cols="12">
              <v-text-field
                v-model="form.address.houseNumber"
                :rules="requiredRules('House number')"
                label="House / Apartment Number"
                placeholder="e.g. 12B/4"
                required
                @focus="Icons.address.houseNumber = true"
                @blur="Icons.address.houseNumber = false"
              >
                <template v-slot:append-inner>
                  <Icon v-if="Icons.address.houseNumber" icon="material-symbols:house" width="24" height="24" />
                </template>
              </v-text-field>
            </v-col>

            <v-col cols="12" class="pa-0 d-flex px-3 gap-2">
              <v-text-field
                v-model="form.address.postalCode"
                :rules="postalCodeRules"
                label="Postal Code"
                placeholder="00-000"
                required
                @focus="Icons.address.postalCode = true"
                @blur="Icons.address.postalCode = false"
                style="max-width: 150px"
              >
                <template v-slot:append-inner>
                  <Icon v-if="Icons.address.postalCode" icon="solar:letter-bold" width="24" height="24" />
                </template>
              </v-text-field>

              <v-text-field
                v-model="form.address.city"
                :rules="requiredRules('City')"
                label="City"
                placeholder="e.g. Warsaw"
                required
                @focus="Icons.address.city = true"
                @blur="Icons.address.city = false"
                class="flex-grow-1"
              >
                <template v-slot:append-inner>
                  <Icon v-if="Icons.address.city" icon="mdi:city" width="24" height="24" />
                </template>
              </v-text-field>
            </v-col>

            <v-col cols="12" class="mt-4">
              <v-btn :disabled="!valid" color="primary" block size="large" @click="test"> Submit Registration </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </v-form>
    </div>
  </div>
</template>

<style scoped>
.bg-black {
  background-image: url('data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxMSEBUSEhIVFRAVFRAVFxUVFRUVFRYVFRUWFhUWFRUYHSggGBolGxUVITEhJSkrLy4uFx8zODMtNygtLisBCgoKDg0OGxAQGi0lHyUrLSsvLy0tLTAtLS0tKy0tLS0tLS0rLSstLS0tLS0tLS0tLS0tLS0tKy0tLS0tLS0tLf/AABEIALcBEwMBIgACEQEDEQH/xAAcAAAABwEBAAAAAAAAAAAAAAAAAQIDBAUGBwj/xABAEAABAwIEAwUECAUDBAMAAAABAAIRAwQFEiExQVFhBhMicYEUMpGhByNCUrHB0fBicpLh8RUzQ4KissIWU3P/xAAaAQADAQEBAQAAAAAAAAAAAAAAAQIDBAUG/8QALxEAAgIBAwMCAwcFAAAAAAAAAAECEQMEEiETMUEiUTKRoQUUUmFxsfAVQoHR4f/aAAwDAQACEQMRAD8A50GJFVyZN4Cm3PUiA4xqm2v8QKRqfJP4e5gqNDzDZknfbWC3jsqA6L9F2Pd3cGi8/V18oE8KoBy/EAj+ldayrzndFlKqTSd9WXAsLcwgt5ZtQux9iO17btopVDF01sngKrR9tvXmPy2tMykvJqYQhLIQAVEiQEHBLhJcUCGKgSITrkmEyBAajypcIwgEIDUeVOhqPKlZVDBRJ4sRtpJ2FDLWynmUU+1iNTZSiJDUCUCUnKgYlz02WJ/KiJRYqGMiJyeKTkTJoYKGVOkBDKmKhgsRZE/AQlFhQxlR92nECUBQ3kSTTTiRBQIHdIIao0BweTRWKkUro7FQ0toWJ2Ex1ZCjV1n1UUuTrGoA0VhcNeG0qpOXUNI1yuJBECRpO/mrfsxcezXdGuD4WPAP8pJa/wD7S5ZVjjAI36KXb13N02ngiyWj0xaXVOqwPpPbUpmQHNMiRuOh6KS1q4n9HOPez3jA5xFOt4Kg4STDHkbSDx5EruJCuzJqhGVMvCfc5IyqiWM5UeVO5UMqBUNZUWVPZUYplAUNNTjQnW0UZ0SKSEZEaJz02XIodoU5yTmQTF3d06QzVHho4SdT0A3J8kCskZkRcoDL2o//AGqLsv3qh7sejfe+QSLd1w57mPLGRBBa0uB9XIFZYlyQU263qgeGo0nkWQD00KXbirlBexuaNQ07fFMOQ4KLKnRUbx8J66fNO90lYbSJkR5FK7pDu0WG0i5EMik5EeRFj2kXIhkUnIiyosNpH7tEWKQQiLUWFEfu0aehGixUeUO0uBVLK5fb1SC5sEObs5rtWujhI4KuI0XT/pxwqLqhXH/LSc13LNSdofOHj+lcyqLNnRF2hAUlr1HCeo0nHYFAywtHwg95J04JFEkEAcOSv7RrXjVpHWNPVIRCsqJGvRd++j/GzeWTHPM1qZ7qp1c0CHf9TSD5yuI1H0aWj6gBOzQJd8FtvojxyiytVY6oKbandsYHyM9QE8dgQDGu8xwVJkPk64WIsqdCUAFRFDOVFlUjIjDUWFDTKfNLSiEkoAQ9yZITxaiLUxDMJuvUaxpc9wa0akuIAHmSouL4xToZWmX136U6LINR56A7DqdAojMEfcEPvcroIc23brRpkagu/wDtd1OnIIEMtxKtc6WjclLjcVGmD/8AjTOr/wCYwPNE3A3UqgqMc6rUIOZ9Utc6ZEb6NZGbRsLRhnBHlRYUNwlJUIQgYSCPKjyoAbqMDgQRIOhCbZQDRDCWx6j4KRlQyoAj27365wAQYBB0I59E7KUWoZUAJlEUrKhlQA2iKcyoZUANIJzKiyoAbhBOZUEAZD6SOzLr6yy0hNem4VKY2zaQ5gJ2JHzAXna6tSx5a8FrgSCCNQQYII6Fevg1cw+k/wCjv2jPdWw+tguqU41cQPfZ/Fzbx3Gu8M1jwcTt3Um7vn/oKeffU9szo6Nj81X16MHXdMkKaLLJuIMb7rXHzIH4J/8A1So5sNhg6b/EqoYE8x0J0IvcKqMaYqDMDuftA82nmFcstmlkDK7eSdJ5ZvTSenVY7vDwKtMJrOzZNSXaADmdAfmkJo7z9GWPGtRNtWcfaKIEZvedS2BniWnSfJbgBci+juyrPvKTmeKjRBzVRIABYQaU/akkacteS7CAqT4IoSglZUeVOx0NlFCdLU1cVWsaXvcGsaCS5xgADiSgVBELN3+OPq1HW1iGvqt0qV3a0KHmR77/AOEesKObmviZLaBdQw+YdX1bVrji2l91v8S02HYbSt6TaVFgZTbsAPiTzJ5p9iaso6PZxlGnUqMHfXpa49/VAc91QCWj+Fk6ZRAgpjBrg95SbTrVauYPNdlRsd0csz7o7s5vDk5GRtK1eVCEWG0Zyo8qdhFlRY6G8qGVOQhCLChvKjypcIQiwoTCOEcI0hiC1FkS0EBQ3kQypxBAUNZEWROoiECoaLERanUIQFDOVGnYQRYURb/EGUveOvJN2OL0arsrHAu5LAmuarjUdUzHaP0TNncG3r94PeI+K85a25VXB1vT0rsg/ST9FznvqXVlDiTmfbgeIH7TqR488vnHJcUq0i1xaQQ4Egg6EEaEEcCvQGD9q6r7lxP9J/JN9scGpXlN761Fvf5T3Tx4XZh7oc4e8DtrtK3+8RuiNjqzgUpbVcOw2mC4Oe9jgTIJaYIOo3aQfMKOa1Jh+rYXn7z/AP1aI+crbcKh/C8LdVBd7rARLzz5AcT+nBSroOpOFG2HjAl7jGYccubYQNT57lSsNxCoKZnWo6O7B+z/ABkcAOA4+ikezeyBhqNz1aoqHKSDMjxF/P3p9Y8pu2I7t9G7Xf6dRzUnU9MwLiCagcA7vDBkTMQddAtQAsLgn0gU30mOdRLaeVoHduzRAiIIG3nwWgodq7R3/NlPJzXj5xHzWpO1l2gmTd0+77zO3u4nOCC30I3WWxDtm5rz3VJr6TeLnOa53MhsaeR36JOSXcFFvsaLGMWpWtI1az8rdgN3Odwa0cSsza4fWxJwrXYNOyBDqdtMGpyfVI4dP8lnszgr7x/t18c7pcKTAIp5A7wuDSTA0247mVu1V12JpvuIp0w0BrQA0AAACAANgAjISkSQ6EQhCUUSAoTCEI0UoCgoQhGhKBUCEUISggAIIIIACJGiQFAQhBCUBQESEokAGiRIICg0ESCAo4/hlRtIAZC5x/FTa7ho9+g5KDZOFR7cjoA4GI/yra7t8zSwkecSvnZ/FyetFel0Iw91BtXvBoTxIj5q1xi7EAiCxsH4QqPun5Q17ARzGhj81TdobjIQGPMHdp4c1eNycqTIklVtE3tl2eoYgwVrdrRcAQSdBUA4OP3hwPp5czr4cLapFUBj2kS1xE8xxgiOq7HgFsG0AdfEAf3Kr+1PY4X1DNLW3Df9t52j7jyPs/gfUHSOv25Gsj4sUtP6fT3OW3OLsaPqT9aXCTEjzk78o+ai3WI1a1TvKrs1SAOQAHADhz+aj4lg1e2eWVqTmmYmDld/K4aGY4KVhmF1HuEgtbPvHQkbaDcngvWi41aZx7W3VG77Dybd8zlzQ0xOoaMx6gz8iOCu3sjXLm46bjrCj4LZNpsDGnK2NBPHiT1nWVbZB9rfg7r1S3WdCjSSI9pfeDI1xy5i7I4kCYglvWByUu0pCrWbSBLQTL6kCA2CNOZOwH5BQcXtR3T3PEQ3MHt192HGY8o05pnstc1KrXkEGm0M1AIku1HhOoMT8VjnnsjvfgFC+Edetm0regxjTFOm1rRJ1gCJJ5qPc49RY8NLhLhIWDr4m7NkqPMQABrqeQA1Oyj1rdzocNTO2xjoDqVzS18n8MRLTryzef8AyejnDCdTPkp1ritN5IDhoYXOb62GhJykJltR1JzXAkx4jy0/vAWeL7Sk6UkVPS+Ys6o+4aN3BELlh+0FzU4k6qcxJlR7+5cBo8geat/aVTraC0j23Z1B90wbuCWKgOxC5F39QtzZ3QepUv22uxmdtR0zxV/1GPlEfdZeDqYQXNMO7X1WHXxDrorq37bCPEw9Nl0R1uJrngyeGa8GxRLGjtwAXSwxw2VphnamjVAk5XRJBWkdTil2ZLxyXgvkFWU8eoOmHjQxuqnE+17GEtpjMRx4Jyz44q2yVCT8GpQXPh20qDcDc/2Tg7a1Mp8IzcFl98xe5fRn7G9RLnFv22rt1e0EdNFZ0+3TTTktObkmtXifkTxT9jZollqfbakROV0RqYSrTtpQedZaOZ0CtajG/wC4XTkvBp0Uqid2stpjOE1d9sLdg0dmPIaqurD3Qtr9jRSiVVRx+g5oOca9UFXUj7ipnOOx7RUaXE6cBs4fzDhxV9d3oYMjaZzHSSFyjCMWfZ1jUdJ8R7tgdq4HdrhBGTj0MlbHB+2VSrUmtbsyaQWEiPOZnz0XlajRzeTdHlHdi1EVGpEu8r1G1gHkgASANj+qVjFpb1qWcuAq8OBlPVe0VCpVDaUF+stMTA3g6gwnbzD6Veo0upkRxGy5pXjaclX6GqakuHZNwMO7hocRMaRKvqTRkA4qjwqy7uqWgkt0gHgrm4JDXGQDsvNztSlwdMOEZythwq1qtKp9ZSfGnIg6QRsZ4rG4z2aq29SKLxUB+y4RUA6n3SNN5C3WEYe9mZ7nF2Z0t5mTp6ap2+o0w4h7RJGrs+pOukHhC9fTxnHzxRhNxfY5sMQNA5arHU38M0EHj4S0HhwlXVhi2doGsc+J8lRdsb9lYi2aWBxMuedQz15nfpKbwqxqNLaLH1DVd4SN2xxJdPu8ZjZeh2Vsxu2aKljOYVKBbIex4Hnl3R9lcWoW1hTex2fvahaJEFuVpPibMkNAJgakFVt52fuLenWuDUpkspvIa3M46DmQOEn0Vd2Otn1rWpSpBveNyPZmAI0OUtzHVmYaSPLUGERWPUxq7Sf8RlmnLG77OjSWNzWeX1qdGrcVZMN8LAyT4WF5OVg2O+sxw0eu8TvqDe8u7AspDdzHtqZR1ykj1kLLtxC8pPDW1Li3aXABhoENDyd+8e0tMkDXoNTAWr7J9rrhtYW945le3d4HOLQ2oyRrnb7tRkb9Oa2lo8Mm20cy1GRJJMmtum1qTajPExwkco5R9kzPrum7uucrco0PA7w3cf1fNqcpYKLWpcUabppCu91MT7rHNYSzyD849FX4g3wvdPhLyGkaaNa1hPkXNcR0M8V4coxU3HvTo9KN7U/cXh9yX5oEEcFLy6ydVWdn2kl+oJgKWKZFQku0jb4rDLGpM6KqKDuquwGmuyeq1PAqx5cah1HrupMuDMx9wHdZuHCJT4INX9hP0w4sngE1UuA45hoIU2hozzBW05NRRNEVjMwnihSpuLuQ/FK3bvESpbXfVjy3SeRoNqory8k5G6kmFO/092QyYI2ULDXtdVkHb+6tq9aQWg6zqoy5JKVI0jBdyA2wAbmzS7kogrAvideIUt7gDBO3FR7qzAb3lLV8q4T/ABPuQ4+xYvYzKBG+6hNosc8tBgJVd+gBEEjVRKDofpwRCMueR8WTqbGtYQDI2TLGAxT4SnM/h05qGKx71ohEL5BpEy8oNZ6iFS0X5Xkbgq6vawJynVQLS1kuf8AtMU6j6iZY7fAhzCTIQU3TkEFXVF00c2wu1zONTxAHbXh57xMq+s7zI4k+7DgY31BEg89VU2F0XNPIE/BHdViKLtfER5au2+UL27dnnVwKdjhLx3YZTY0+EZWh4I+13gaTPqtjZfSJ4Ax9LxcXsc2PMMdHwlczYQOifpMzeFoJc6AANSSTAAA3MpZcGPKkpq6FGUo9jq/Z3tUyvcSDVaGj7bAGT/O1xE9FtKtcv0yzx8WojfbiY4LP9muzLmMaXQ1zQMlOR4YG55v48h57Xb8tIS50ugiOOv56fJefk0uLcpRXb5HdCUkqbE29+57TnbFPxTmbB5NA47CZ4SoFvRNbxPgUgSGsbrmjSD0EepPxy2P9rGlxp0z4RMu/EA8deKqsHvXEHuaha1+7ZIB6ggyD1W0sTlGk6/MXc6diNpSdR8VJrz90safkQmuz1hb0aTnNoNpPeCDAgxrA6Dosng/aY0KjWl+dsEup1HE+Ee8cxOh6/JdBdjFg+k2q6qxrHCRme1vyJXH9wywVQaaf6/tyW80F8SKm7axwI3YQ4EcwZH4Fcz7N1mWGI1KReHW8lhdMgNP2XEbObseoXQMa7aYfSpuNEitUGzWE5ZMwXPiANPNcmu6XtDzcV2xVrvb3AYO7zgTneBM934csncuMHRdf2fpsuFvf2f8APY5tXlx5Ekjf9tsNq3lBjrd3emgAGkOgCmXB1Op6e6Sdg3qubdomV2VaVWpArhrW5miJcyYnXXTTrGy2eC3PcNdUa50U2Brqcl2eXFuUATuADI4wOhPtbgF7cdw7um92W5e7nx0i53/JP2YDZImI12EepknGPxM4ccZN8IhtuKt0+i+lULCaTC4DNLGklxe0jjmlpk6+HqtbeEZQxoEQABwAjQK77OYLa2tFlPdzWNa58QXRz6STp1Vv3dqNwvD1W7LJbUqX5nqYUoRd3bMZgNkKTZiHEp2+oy/M3gNVrm29s7YJFTD7fkQuKWDM5bm18zdTjtrk50yoA6agO8D4lT69w11saQmM0+kg/ktWLO2DphOVLW1iS0H9+S1ljnw1XzEpKv8AhhS1umXZJxWk40waboP+T+i3Bs7P7o+X6InWVmBMaJKGS7pfMVqjFvGnSEdwPq3AGOXzWyNjZ8kh+GWnJLpT9l8xuSMLhNt3BJJkako8Ov8AO94OgzaHpIWzq4Xancn4oqeGWh2PRN45StyXP6oFKuzMpfVcjhHimITra3u6RMH4QtQ7B7URLj01RNwi1B0cUujL2+qGpIyuKXAc4HaAJRZ+7IBGrmn/AMT+hWqfhFrxdqlXGFWzjLn6xorjjnVOP1Qtyu7Mm+vsAIGv5Jhj9HP+7J+J0WtGC23F5+KQ/BbWIDzHHVPpy/D9UG5e5kn1hU8Y08JKjWlWo1nAySPnC2IwC1mQ/SNktmC2n3lXTlVbf2/2LcvcoHFoMFGtM7Brf734IKOlP8P1RW+PucHwweAN18Wug+IUvGD9WS6mWkBkOkcXaBwH+VW2dfSPkp1QipSLST4QYAJAkAkGJ1Pmvb8nmeCpaZMdQN9PUldT7F2NvahtRwz1nRFVwDWDMPdp8W8szgCemy5jhuH1a1QMZTc48co26knQepT17bV6DnNeyowzxBy+YdtHVW9r9LZKbXKPRJxOmx0SBLSeoIkkHposb2lxZ1XM2n7hkkzBdOh9IHqs7Tx4up06ZfPgZncDo90AGD93T1IR3JOXwt0iAZ/BclUd8I7lZmquFd48hriDMQCfEeQBKs8DwRzHFjqvdgjMDprBIIEjQjjI4KXY2/eBopw2q0TrxcJ+G8fBOvfSqs7u4ztrNcTIMEE7mOPEq9/gfTXcjXPZhlQipTuTrOfvGgkD+HKQ1TLTBaHfUqT61V7C4MIlg1do1w8OniIUA2JaYp3Pg6sjTrBharsphVDu+/1fWY97Q4yGggDVrQYmDvqpy5nCF2R0ot9gX3Yi2LHNY6oHwcpcWluYbZm5dQqG/wCyd5WYypVqUqlalLGsIlppawC6I0JJAy8Vt6jyJlJo1Nlwx1maK7jlgxt9jNdgcGfaOqvqubnIhrG6tZrMyePARsFt3XksBWWY5wrvHAqwfUIaAs88pzluZpjUYxpE2re6qPiGJEDRQrlxncKBiJPNEFdCk+GXeE4s4jXgpFbGHF0Dks1hAcAdCn3OcHHQ7InH1Mq/SicMQcXaqVUuiaW8GVnXVDm2KkVHnu4g78lT8EJuibVxCNEm5vSWiCf3KqC8z7pT7S7L7pVNVTFZYG8MblPOuiWnxFU7S6NlIGYtiEv8BY/Z3jiYLpS6VUguM8f0VbZMcHag7qXUfEpT4ZcR+tduJGqU68IjxKtNTVN1XoihWWV5dGRB4IjeuLhrsPyKhV3zCbpA5lUewr5LT2p3NI9tdqOaicFGLjmGqaFZPqXLm6TwKjUL50QTxQvHqFRfqdE48oGXZxA80FXBx5H4IJUPcYan2XuyZFu74sHyLlLt8AvA8Tbv3EzliJ1nVdGta6Rc3K6HqZt1SOfpKrspeymAm2fUe8jNU0DAZDGzME8Tt8FOxS6MgCd1NtHZnKDiLvGNOIWablO5DdKNIvKlKnVohlRjXtgaOEx5cj5KpveypYGvtX+EGTSqHMNNRkdv6O+IU7vvCNFKZekNDQ0k+q54rJGXpfk33xS5MSKbakuD+6uA5wLHA5dzAPFsbeSjVqLqj2tqUXPfIDTTJdJOwBbr6GF0Cl2coXL/AK6l49s4c5ro8wdfWVe4L2Go2zxUD6tQtMtFRzcrTESA1ok+cr08cXLkxlqImQ7M9imVGOfc0HtOZoY2o94dAmSWgggaj3tdD67m1wwU6QZTYxrANGgQArOpQEJwUNNFUsFs5+s+TL3+GHcsEKEyhTkACPRai9t3Zd1R0MNIqTJ+AWE9Pzwio5n5K1/Z4GoXiqB0ypm8w6CB3jf36rWVrYgcvRVlxatL4JE/y/2RlwIIZn5MncUSHxw5yP1R+yAnxT6R+quK2Ey+fy/srCxs3HhInksceF8Gk8qM7b2YbMOcPOFK7l/B7fULQ17ET7nySvYxGrY6LTovcJ5vSZwWtQGfAfRWgzZR4Gfv0Ui4wwHYQE57NGkn4K1hZm8hFo0pOrGypgtdNWNTlK0fwOnkFIpWxG5XQsaMXJleLdv3G/BOMteTWqb7L1S2WfNV00G5lQKAB9xqaubZpB+rB8pV57GJTFzYclE8NlRm0ZI2bZ/2T8f7pPsjRP1R+JWjo2h2dz5JTrIbrJYCusZx9mHDSmR6pFK0aPepu9D/AHWnpW3Qp11kI2/FNacfWZnqdhRc3Vj0TMKtifcctK21gbfikNszM6qlgol5WUVxZUm7UyVFFJnGiR6D9Fqn23OUl9AfuE1hoTyMoqdGnA8B+A/RBXraOiCrpC3sw1Ci4N2PqEuysBUk940RwcP1KvMSw+rrrPqpGB9nyaLpBBM85/Fc0ML3co1ll44IWH4W0NP1rPQBQ2YTneSXCG8oWpw/svSazxAyZ3n9U/bYTSZIa3Q8pW8cHqujNzdFJbYBnbnD9umin4PhPjlx0HRaOwtsrMrRonKFsG8FosEU7E5tqhDKTQ7b5BSswRZQhK2JAWjkjDAhKKUAJq24KjssxOykygihDdW3EbSor7VszlCnFBKh2V7bUA7JyhRA2CkkdEQPRG1BYy+2BKQ63jgpUoi5FBZDNuDuERt2jZSyUUooCPSohO90EuURKdCER0Sg1AOQlAWJNMInU0uUJQBHFBB1IJ+URRQEdtGNtUCOifhGigGmpLmBOlEAigGTQBRezjmniECigGu6HNEnPRGigslvswTJTtGhlEBBBAw+7EbomAcEEECDlJlBBMAsyKUEEADMilBBAgZkMyCCACzIZkEEAAuSS5GggBOZEXIIIEFmQzIIIGFmScyCCBAzIZkSCABmQzIIIAGZDMgggAShKCCAClESgggAsyBcgggApQQQQKz/2Q=='); /* Twój base64 */
  background-size: cover;

}
.gap-2 {
  gap: 8px;
}
.card-color{
 background-color: rgba(0, 0, 0, 0.5);
}

</style>

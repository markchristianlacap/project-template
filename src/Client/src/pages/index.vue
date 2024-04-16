<script setup lang="ts">
const userStore = useUserStore()
const loading = ref(false)
const router = useRouter()
const errors = ref<Record<string, string[]>>({})
const form = ref({
  email: '',
  password: '',
})
async function login() {
  try {
    loading.value = true
    errors.value = {}
    await userStore.login(form.value)
    router.push('/user')
  }
  catch (e: any) {
    errors.value = e?.response?.data?.errors || {}
  }
  loading.value = false
}
</script>

<template>
  <div class="mt-[200px]">
    <Card class="w-[500px] m-auto">
      <template #title>
        Login to your account
      </template>
      <template #subtitle>
        Please enter your email and password to login to your account.
      </template>
      <template #content>
        <form @submit.prevent="login">
          <Message v-if="errors.generalErrors" severity="error">
            {{ errors.generalErrors[0] }}
          </Message>
          <div class="flex flex-col gap-2">
            <label for="email">Email</label>
            <InputText v-model="form.email" placeholder="Enter your email" type="email" :invalid="!!errors.email" />
            <small v-if="!!errors.email" class="text-red-500">{{ errors.email[0] }}</small>
          </div>
          <div class="mt-4 flex flex-col gap-2">
            <label for="password">Password</label>
            <Password v-model="form.password" toggle-mask :feedback="false" placeholder="Enter your password" :invalid="!!errors.password" />
            <small v-if="!!errors.password" class="text-red-500">{{ errors.password[0] }}</small>
          </div>
          <div class="mt-8">
            <Button label="Login" :loading="loading" type="submit" />
          </div>
        </form>
      </template>
    </Card>
  </div>
</template>

<route lang="yaml">
meta:
  layout: home
  auth: guest
</route>

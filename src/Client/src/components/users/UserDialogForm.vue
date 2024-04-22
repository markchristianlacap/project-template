<script setup>
const dialog = defineModel('dialog')
const form = defineModel('form', { default: {} })
const toast = useToast()
const loading = ref(false)
const errors = ref({})
async function submit() {
  try {
    loading.value = true
    if (!form.value.id)
      await api.post('/users', form.value)

    else
      await api.put(`users/${form.value.id}`, form.value)
    dialog.value = false
    toast.add({ detail: 'User saved successfully', severity: 'success' })
  }
  catch (e) {
    errors.value = e ? e.response.data.errors : {}
  }
  loading.value = false
}
watch(dialog, (v) => {
  if (!v) {
    form.value = {}
    errors.value = {}
  }
})
</script>

<template>
  <Dialog v-model:visible="dialog" modal header="User Form">
    <form @submit.prevent="submit">
      <div class="mb-3 flex flex-col gap-3">
        <label for="name">Name</label>
        <InputText v-model="form.name" placeholder="Enter user name" />
        <small v-if="errors.name" class="text-red-500">
          {{ errors.name[0] }}
        </small>
      </div>
      <div class="mb-3 flex flex-col gap-3">
        <label for="email">Email</label>
        <InputText v-model="form.email" placeholder="Enter user email" />
        <small v-if="errors.email" class="text-red-500">
          {{ errors.email[0] }}
        </small>
      </div>
      <div v-if="!form.id" class="mb-3 flex flex-col gap-3">
        <label for="password">Password</label>
        <Password v-model="form.password" type="password" placeholder="Enter user password" />
        <small v-if="errors.password" class="text-red-500">
          {{ errors.password[0] }}
        </small>
      </div>
    </form>
    <template #footer>
      <Button label="Cancel" severity="danger" :disabled="loading" @click="dialog = false" />
      <Button label="Submit" :loading="loading" @click="submit" />
    </template>
  </Dialog>
</template>

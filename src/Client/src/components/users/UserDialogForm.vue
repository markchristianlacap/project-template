<script setup lang="ts">
import { type UserStoreReq, type UserUpdateReq, usersApi } from '~/api/users'
import { Role } from '~/enums/role'
import { roles } from '~/options/roles'
import type { Errors } from '~/types/errors'

type IForm = UserStoreReq & UserUpdateReq
const props = defineProps<{
  dialog: boolean
  form: IForm
  id?: string
}>()
const emits = defineEmits<{
  'success': []
  'update:dialog': [boolean]
  'update:form': [IForm]
}>()
const { dialog, form } = useVModels(props, emits)
const toast = useToast()
const loading = ref(false)
const errors = ref<Errors<typeof form.value>>({})
async function submit() {
  try {
    loading.value = true
    if (props.id)
      await usersApi.update(props.id, form.value)
    else
      await usersApi.store(form.value)

    dialog.value = false
    toast.add({ detail: 'User saved successfully', severity: 'success' })
    emits('success')
  }
  catch (e) {
    if (isAxiosError(e))
      errors.value = e?.response?.data?.errors
    else
      toast.add({ detail: 'Something went wrong', severity: 'error' })
  }
  loading.value = false
}
watch(dialog, (v) => {
  if (!v) {
    form.value = { email: '', name: '', password: '', isActive: true, role: Role.User }
    errors.value = {}
  }
})
</script>

<template>
  <Dialog v-model:visible="dialog" modal header="User Form">
    <form @submit.prevent="submit">
      <div class="mb-sm flex flex-col gap-2">
        <label for="name">Name</label>
        <InputText v-model="form.name" placeholder="Enter user name" :invalid="!!errors.name" />
        <small v-show="errors.name" class="text-red-500">
          {{ errors?.name?.[0] }}
        </small>
      </div>
      <div class="mb-sm flex flex-col gap-2">
        <label for="email">Email</label>
        <InputText v-model="form.email" type="email" placeholder="Enter user email" :invalid="!!errors.email" />
        <small v-show="errors.email" class="text-red-500">
          {{ errors?.email?.[0] }}
        </small>
      </div>
      <div v-if="!id" class="mb-sm flex flex-col gap-2">
        <label for="password">Password</label>
        <Password v-model="form.password" type="password" placeholder="Enter user password" :invalid="!!errors.password" />
        <small v-show="errors.password" class="text-red-500">
          {{ errors?.password?.[0] }}
        </small>
      </div>
      <div class="mb-sm flex items-center gap-2">
        <label for="role">Role</label>
        <Dropdown v-model="form.role" :options="roles" option-label="label" option-value="value" placeholder="Select role" />
      </div>
      <div class="flex items-center gap-2">
        <Checkbox v-model="form.isActive" name="active" input-id="isActive" :binary="true" />
        <label for="isActive">
          Active
        </label>
      </div>
      <div class="mt-xl flex justify-end gap-sm">
        <Button label="Cancel" severity="danger" :disabled="loading" @click="dialog = false" />
        <Button label="Submit" :loading="loading" @click="submit()" />
      </div>
    </form>
  </Dialog>
</template>

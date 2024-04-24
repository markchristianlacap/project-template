import type { Errors } from '~/types/errors'

export function useForm<T>(fields: T) {
  return reactive({
    fields,
    loading: false,
    errors: { } as Errors<T>,
    async submit(submitter: (fields: T) => Promise<void>) {
      if (this.loading)
        return
      this.errors = {}
      this.loading = true
      try {
        await submitter(this.fields)
      }
      catch (e) {
        if (isAxiosError(e))
          this.errors = e?.response?.data?.errors || {}
        else
          throw e
      }
      this.loading = false
    },
  })
}

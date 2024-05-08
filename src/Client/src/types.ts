import type { ViteSSGContext } from 'vite-ssg'
import type { RouteRecordRaw, Router } from 'vue-router/auto'

interface AppContext<HasRouter extends boolean = boolean> extends Omit<ViteSSGContext<HasRouter>, 'router' | 'routes'> {
  router: HasRouter extends true ? Router : undefined
  routes: HasRouter extends true ? Readonly<RouteRecordRaw[]> : undefined
}

export type UserModule = (ctx: AppContext) => void

export function useScreenResolutions() {
  const { width, height } = useWindowSize()
  const isMobile = computed(() => width.value < 768)
  const isTablet = computed(() => width.value >= 768 && width.value < 1024)
  const isDesktop = computed(() => width.value >= 1024)
  return {
    isMobile,
    isTablet,
    isDesktop,
    width,
    height,
  }
}

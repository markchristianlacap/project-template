export function formatDate(date?: string, format = 'MMM DD, YYYY HH:mm:ss') {
  if (!date)
    return ''
  const formatted = dayjs(date).format(format)
  return formatted
}

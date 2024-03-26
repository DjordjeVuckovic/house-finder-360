export function truncateString(str: string, maxLength: number) {
  if (str.length <= maxLength) return str

  let truncated = str.substring(0, maxLength)

  // Find the last space within the truncated string
  const lastSpace = truncated.lastIndexOf(' ')

  // If a space was found, truncate after that space
  if (lastSpace !== -1) {
    truncated = truncated.substring(0, lastSpace)
  }

  return truncated + '...'
}

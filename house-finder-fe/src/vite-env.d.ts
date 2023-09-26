/// <reference types="vite/client" />
interface ImportMetaEnv {
    readonly VITE_BE_BASE_URL: string
    readonly VITE_GOOGLE_MAP_KEY: string
    // more env variables...
}

interface ImportMeta {
    readonly env: ImportMetaEnv
}
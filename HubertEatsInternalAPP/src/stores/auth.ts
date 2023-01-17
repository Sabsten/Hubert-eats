import { defineStore } from 'pinia';
import jwt_decode from 'jwt-decode';

export type TokenPayload = {
    role: string,
    identifiant: string,
}

function getTokenPayload(): TokenPayload | null {
    const token = localStorage.getItem('TOKEN');
    if(token === null) {
        return null
    }
    return jwt_decode<TokenPayload>(token);
}

export const useAuthStore = defineStore({
    id: 'Auth',
    getters: {
        getRole: (): string | null => {
            const payload = getTokenPayload();
            return payload === null ? null : payload.identifiant;
        },
        getIdentifiant: (): string | null => {
            const payload = getTokenPayload();
            return payload === null ? null : payload.role;
        }
    },
    actions: {
        async signIn(identifiant: string, password: string): Promise<string | null> {
            const URL: string = import.meta.env.VITE_ACCOUNT_SERVICE_URL + 'internal/signin';
            const RES: Response = await fetch(URL, {
                method: "POST",
                headers: {"Content-Type": "application/json"},
                body: JSON.stringify({identifiant: identifiant, password: password})
            });
            const data = await RES.json();
            if (!RES.ok) {
                return data.error;
            }
            localStorage.setItem('TOKEN',data.token)
            console.log('Request successful');
            return null
        },
    }
})

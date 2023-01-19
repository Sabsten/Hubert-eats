import { defineStore } from 'pinia';
import jwt_decode from 'jwt-decode';

export type TokenPayload = {
    role: string,
    identifiant: string,
}

export function getIdentifiant(): string | undefined{
    return getTokenPayload()?.identifiant
}
export function getRole(): string | undefined{
    return getTokenPayload()?.role;
}

export function isAuthentified(): boolean {
    return getTokenPayload() !== null ? true : false;
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
            if (localStorage.getItem("TOKEN") === null) {
                localStorage.setItem("TOKEN",data.token)
            } else if (localStorage.getItem("TOKEN") !== data.token) {
                localStorage.setItem("TOKEN",data.token)
            } else {
                console.log('Token already exist');
            }
            console.log('Request successful');
            return null
        },
    }
})

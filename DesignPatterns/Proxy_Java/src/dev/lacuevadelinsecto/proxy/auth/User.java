package dev.lacuevadelinsecto.proxy.auth;

import dev.lacuevadelinsecto.proxy.auth.Authorization.Role;

public record User(String username, Role role) {
    public String getUsername()
    {
        return  username;
    }

    public Role getRole()
    {
        return  role;
    }
}

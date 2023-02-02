package dev.lacuevadelinsecto.proxy.auth;

public class Authorization {

    private final User user;

    public Authorization(User user) {
        this.user = user;
    }

    public boolean canReadWriteAccess() {
        return user.getRole().equals(Role.READ_WRITE_USER);
    }

    public enum Role {
        READ_WRITE_USER,
        READ_ONLY_USER
    }
}

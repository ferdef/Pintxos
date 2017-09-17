class UsersController < ApplicationController
    def new
        @user = User.new
    end
    def create
        @user = User.new(user_params)
        if @user.save
            flash[:notice] = "Usuario dado de alta con éxito"
            flash[:color] = "valid"
        else
            flash[:notice] = "Los datos son inválidos"
            flash[:color] = "invalid"
        end
        render "new"
    end

    private

    def user_params
        params.require(:user).permit(:username, :name, :password, :password_confirmation)
    end
end

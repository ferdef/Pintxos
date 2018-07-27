Rails.application.routes.draw do
  # For details on the DSL available within this file, see http://guides.rubyonrails.org/routing.html
  get 'about', to: 'welcome#about', as: 'about'
  resources :votes
  resources :users
  root 'welcome#index'
end

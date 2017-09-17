class Pincho < ApplicationRecord
    has_many :users
    has_many :users, through: :votes
end

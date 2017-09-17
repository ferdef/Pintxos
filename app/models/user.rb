class User < ApplicationRecord
    has_many :votes
    has_many :pinchos, through :votes
end

# Dungeon_Crawler_Final
Đồ án Cuối kỳ Phát Triển Game: Dungeon Crawler

 **Nhóm 12: Game End**  
      1612286 - Nguyễn Hồng Khang   
      1612290 - Long Vĩ Khang    

# Thông tin cơ bản về game:

    Người chơi xuất hiện tại màn đầu của game, người chơi có thể nhặt các vật phẩm nằm rải rác trong khu vực và sử dụng để tăng sức tấn công, phòng thủ.
    Người chơi có thể đi vòng quanh các khu vực tùy ý, hiện đang có 3 khu vực: Desert, Fortress và Lair.
    Người chơi có thể tương tác với các Viên pha lê khổng lồ, chức năng của chúng là dịch chuyển người chơi qua các khu vực tùy chọn.
    Người chơi có thể tương tác với các NPC, mỗi NPC sẽ có đoạn hội thoại khác nhau, có một vài NPC khi người chơi bắt chuyện thì sẽ giao cho người chơi Nhiệm vụ.
    Người chơi sau khi nhận Nhiệm vụ thì đi thực hiện, nếu hoàn thành thì quay về và nói chuyện với NPC đã giao nhiệm vụ thì sẽ được thưởng.
    Tùy vào trạng thái của Nhiệm vụ thì hội thoại của NPC giao nhiệm vụ đó thay đổi khi Người chơi tương tác với NPC đó.

# Các chức năng đã thực hiện
    - Nhiệm vụ:
      + Slaying Quest: yêu cầu đánh bại đúng số lượng của loại quái vật nhất định.

    - Người chơi:
      + Có thể thay đổi tùy chỉnh trong Game Menu bằng cách nhấp Escape khi đang chơi và chọn mục Options.
      + Di chuyển bằng cấm nhấp chuột trái tại một điểm trên khu vực.
      + Tấn công bằng Space.
      + Nhặt vật phẩm bằng cách nhấp chuột trái vào vật phẩm.
      + Bấm I để mở kho đồ, nhấp chuột trái vào trang bị thì cho thấy mô tả của trang bị đó, nhấp vào Equip/ Use để sử dụng món trang bị.
      + Có thể sử dụng mỗi lọ Potion Log để hồi 30 HP.
      + Trang bị giúp người chơi có sức tấn công cao hơn.
      + Tùy vào sức tấn công mà trừ máu khi tấn công đối thủ.
      + Hiện đang có 2 loại vũ khí: Sword và Staff, Sword đánh tầm gần, Staff có thể bắn cầu lửa để tấn công đối thủ.
      + Khi bị đánh bại thì quay lại từ đầu của màn chơi.
      
    - Quái vật:
      + Hiện có 3 loại quái vật:
            . Slime: máu thấp, tốc độ di chuyển cao.
            . Spitfire: máu trung bình, tốc độ di chuyển trung bình.
            . Cyclop: máu rất cao, tốc độ di chuyển thấp.
      + Khi không thấy người chơi thì sẽ đứng yên, thấy người chơi thì đuổi theo, đến đủ gần người chơi thì sẽ tấn công. Khi bị đánh bại thì biến mất.
      + Có sức tấn công, máu nhất định.
